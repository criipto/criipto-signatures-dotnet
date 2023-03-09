const fs = require('fs');
const typesSupressions = `#pragma warning disable CS8601
#pragma warning disable CS8603
#pragma warning disable CS8604 
#pragma warning disable CS8618
#pragma warning disable CS8619
#pragma warning disable CS0111`;

const operationsSupressions = `#pragma warning disable CS8625`;


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

types = typesSupressions + '\n\n' + types;
fs.writeFileSync(__dirname + '/Criipto.Signatures/Types.cs', types);

let operations = fs.readFileSync(__dirname + '/Criipto.Signatures/Operations.cs').toString();
operations = operationsSupressions + '\n\n' + operations;
fs.writeFileSync(__dirname + '/Criipto.Signatures/Operations.cs', operations);