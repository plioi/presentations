Framework '4.0'

properties {
    $project = "FileImporter"
    $birthYear = 2013
    $maintainers = "Headspring"
    $description = "A refactoring demo."

    $configuration = 'Release'
    $src = resolve-path '.\src'
    $version = '0.0.0.1'
}

task default -depends Test

task Test -depends Compile {
    NUnit "Iteration00"
}

task Compile -depends CommonAssemblyInfo {
  exec { msbuild /t:clean /v:q /nologo /p:Configuration=$configuration $src\$project.sln }
  exec { msbuild /t:build /v:q /nologo /p:Configuration=$configuration $src\$project.sln }
}

task CommonAssemblyInfo {
    $date = Get-Date
    $year = $date.Year
    $copyrightSpan = if ($year -eq $birthYear) { $year } else { "$birthYear-$year" }
    $copyright = "Copyright (c) $copyrightSpan $maintainers"

"using System.Reflection;
using System.Runtime.InteropServices;

[assembly: ComVisible(false)]
[assembly: AssemblyProduct(""$project"")]
[assembly: AssemblyVersion(""$version"")]
[assembly: AssemblyFileVersion(""$version"")]
[assembly: AssemblyCopyright(""$copyright"")]
[assembly: AssemblyCompany(""$maintainers"")]
[assembly: AssemblyDescription(""$description"")]
[assembly: AssemblyConfiguration(""$configuration"")]" | out-file "$src\CommonAssemblyInfo.cs" -encoding "ASCII"
}

function NUnit($projectName) {
    $nunitRunner = join-path $src "packages\NUnit.Runners.2.6.2\tools\nunit-console.exe"
    & $nunitRunner $src\$projectName\bin\$configuration\$projectName.dll /nologo /nodots /framework:net-4.0

    if ($lastexitcode -gt 0)
    {
        throw "{0} unit tests failed." -f $lastexitcode
    }
    if ($lastexitcode -lt 0)
    {
        throw "Unit test run was terminated by a fatal error."
    }
}