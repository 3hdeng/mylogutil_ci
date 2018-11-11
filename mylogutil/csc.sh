#!/bin/bash
ref1=~/.nuget/packages/microsoft.extensions.logging.abstractions/2.0.0/lib/netstandard2.0/Microsoft.Extensions.Logging.Abstractions.dll
ref2=~/.nuget/packages/microsoft.extensions.configuration.abstractions/2.0.0/lib/netstandard2.0/Microsoft.Extensions.Configuration.Abstractions.dll

csc -target:library -reference:$ref1,$ref2  $1
