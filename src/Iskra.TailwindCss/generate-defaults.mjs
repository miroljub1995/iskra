import { readFileSync } from "node:fs";
import { writeFileSync } from "node:fs";
import { dirname } from "node:path";
import { fileURLToPath } from "node:url";
import { join } from "node:path";

const __dirname = dirname(fileURLToPath(import.meta.url));
const twDir = join(__dirname, "node_modules", "tailwindcss");

const files = [
  { name: "ThemeCss", file: "theme.css" },
  { name: "PreflightCss", file: "preflight.css" },
  { name: "UtilitiesCss", file: "utilities.css" },
  { name: "IndexCss", file: "index.css" },
];

const consts = files
  .map(({ name, file }) => {
    const content = readFileSync(join(twDir, file), "utf-8").trimEnd();
    return `    public const string ${name} =\n"""\n${content}\n""";`;
  })
  .join("\n\n");

const cs = `namespace Iskra.TailwindCss;

public static class TailwindCssDefaults
{
${consts}
}
`;

const outPath = join(__dirname, "TailwindCssDefaults.cs");
writeFileSync(outPath, cs, "utf-8");
console.log(`Wrote TailwindCssDefaults.cs (${(cs.length / 1024).toFixed(1)} KB)`);
