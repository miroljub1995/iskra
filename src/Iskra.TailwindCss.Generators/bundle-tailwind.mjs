// Cross-compile Tailwind CSS compiler CLI into standalone executables using Bun.
//
// Usage:
//   bun run bundle-tailwind.mjs
//
// Prerequisites:
//   bun install
//
// Output:
//   runtimes/osx-arm64/tailwind-compiler
//   runtimes/osx-x64/tailwind-compiler
//   runtimes/linux-arm64/tailwind-compiler
//   runtimes/linux-x64/tailwind-compiler
//   runtimes/win-x64/tailwind-compiler.exe

import { $ } from "bun";
import { mkdirSync } from "node:fs";

const targets = [
  { rid: "osx-arm64", bunTarget: "bun-darwin-arm64", exe: "tailwind-compiler" },
  { rid: "osx-x64", bunTarget: "bun-darwin-x64", exe: "tailwind-compiler" },
  { rid: "linux-arm64", bunTarget: "bun-linux-arm64", exe: "tailwind-compiler" },
  { rid: "linux-x64", bunTarget: "bun-linux-x64", exe: "tailwind-compiler" },
  { rid: "win-x64", bunTarget: "bun-windows-x64", exe: "tailwind-compiler.exe" },
];

for (const { rid, bunTarget, exe } of targets) {
  const outDir = `runtimes/${rid}`;
  mkdirSync(outDir, { recursive: true });
  const outPath = `${outDir}/${exe}`;
  console.log(`Building ${bunTarget} → ${outPath}`);
  await $`bun build tailwind-compiler.ts --compile --target=${bunTarget} --outfile=${outPath}`;
}

console.log("Done — all targets built.");
