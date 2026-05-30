using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace Iskra.TailwindCss.Generators;

internal static class TailwindCompiler
{
    internal static string BuildCss(string css, Dictionary<string, string> importMap, string[] candidates, string runtimesDir)
    {
        var exePath = GetExecutablePath(runtimesDir);

        var input = JsonSerializer.Serialize(new { css, importMap, candidates });

        using var process = new Process();
        process.StartInfo = new ProcessStartInfo
        {
            FileName = exePath,
            RedirectStandardInput = true,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true,
        };

        process.Start();
        process.StandardInput.Write(input);
        process.StandardInput.Close();

        var output = process.StandardOutput.ReadToEnd();
        var error = process.StandardError.ReadToEnd();
        process.WaitForExit();

        if (process.ExitCode != 0)
        {
            throw new InvalidOperationException(
                $"tailwind-compiler exited with code {process.ExitCode}: {error}");
        }

        return output;
    }

    private static string GetExecutablePath(string runtimesDir)
    {
        var rid = GetRuntimeIdentifier();
        var exe = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
            ? "tailwind-compiler.exe"
            : "tailwind-compiler";

        // Use the runtimes directory from MSBuild property if provided
        if (!string.IsNullOrEmpty(runtimesDir))
        {
            var path = Path.Combine(runtimesDir, rid, exe);
            if (File.Exists(path))
                return path;
        }

        // Fallback: look relative to the assembly location (works in tests)
        var assemblyDir = Path.GetDirectoryName(typeof(TailwindCompiler).Assembly.Location);
        if (!string.IsNullOrEmpty(assemblyDir))
        {
            var path = Path.Combine(assemblyDir, "runtimes", rid, exe);
            if (File.Exists(path))
                return path;
        }

        throw new FileNotFoundException(
            $"tailwind-compiler binary not found for '{rid}'.");
    }

    private static string GetRuntimeIdentifier()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            return RuntimeInformation.OSArchitecture == Architecture.Arm64 ? "osx-arm64" : "osx-x64";
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            return RuntimeInformation.OSArchitecture == Architecture.Arm64 ? "linux-arm64" : "linux-x64";
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            return "win-x64";
        throw new PlatformNotSupportedException();
    }
}
