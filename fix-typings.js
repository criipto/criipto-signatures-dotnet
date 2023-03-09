const fs = require('fs');
const typesSupressions = [
  'CS8601',
  'CS8603',
  'CS8604',
  'CS8618',
  'CS8619',
  'CS0111',
  'CA1507',
  'CA1715',
  'CA1724',
  'CA1062',
  'CA2227',
  'CA1724',
  'CA1002',
  'CA1034',
  'CA1056',
  'CA1707',
  'CA1720',
  'CA1052'
]

const operationsSupressions = [
  'CS8625',
  'CA1052',
  'CA2211'
];


let types = fs.readFileSync(__dirname + '/Criipto.Signatures/Types.cs').toString();

let compositionTypes = [...types.matchAll(/public interface (.+) \{/g)].map(result => result[1]);

for (const compositionType of compositionTypes) {
  const listRegex = new RegExp(`^(.*?)List<${compositionType}>(.*?)$`, 'gm');
  types = types.replace(listRegex, function (match) {
    var indent = match.match(/^\s+/);
    return indent[0] + '[JsonConverter(typeof(CompositionTypeListConverter))]\n' + match;
  });

  const typeRegex = new RegExp(`^(.*?)(public|private|protected) ${compositionType} (.*?)$`, 'gm');
  types = types.replace(typeRegex, function (match) {
    if (match.includes('class') || match.includes('interface')) return match;
    var indent = match.match(/^\s+/);
    return (indent ? indent[0] : '') + '[JsonConverter(typeof(CompositionTypeConverter))]\n' + match;
  });
}
types = types.replace(/List\<SignatureEvidenceProvider\>/g, 'List<object>');
types = types.replace(/public SignatureEvidenceProvider/g, 'public object');

types = typesSupressions.map(s => `#pragma warning disable ${s}`).join('\n') + '\n' + types;
fs.writeFileSync(__dirname + '/Criipto.Signatures/Types.cs', types);

let operations = fs.readFileSync(__dirname + '/Criipto.Signatures/Operations.cs').toString();
operations = operationsSupressions.map(s => `#pragma warning disable ${s}`).join('\n') + '\n' + operations;
fs.writeFileSync(__dirname + '/Criipto.Signatures/Operations.cs', operations);