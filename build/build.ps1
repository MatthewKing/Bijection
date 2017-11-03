$root = Resolve-Path (Join-Path $PSScriptRoot "..")
$project =  "$root/src/Bijection"
$output = "$root/artifacts"
dotnet msbuild "/t:Restore;Build;Pack" "/p:Configuration=Release" "/p:PackageOutputPath=$output" $project
