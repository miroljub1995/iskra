// Tailwind CSS compiler CLI
// Reads JSON from stdin: { css, importMap: { [id]: content }, candidates: string[] }
// Writes compiled CSS to stdout

import { compile } from "tailwindcss";

const input = await Bun.stdin.text();
const { css, importMap, candidates } = JSON.parse(input);

const compiled = await compile(css, {
  loadStylesheet: async (id, base) => {
    const content = importMap[id];
    if (content === undefined) {
      throw new Error(`Unknown stylesheet import: '${id}'`);
    }
    return { path: id, base: "", content };
  },
});

const result = compiled.build(candidates);
process.stdout.write(result);
