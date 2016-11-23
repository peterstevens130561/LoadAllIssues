
"C:\Program Files\SonarQube\MSBuild.SonarQube.Runner.Exe" begin /k:SonarQubeTools /v:main /n:SonarQubeTools  /d:sonar.dotnet.version=4.5 ^
	/d:sonar.visualstudio.testProjectPattern=(?i)(.*UnitTest.*)  ^
	/d:sonar.resharper.inspectcode.profile=E:\Development\Radiant\Main\BHI.AutoLoad.DotSettings ^
	/d:sonar.dotnet.buildConfiguration=Release /d:sonar.dotnet.buildPlatform=x64 ^
	/d:sonar.mscover.vstest.testsettings=unittests.runsettings ^
	/d:sonar.visualstudio.outputPaths=bin/x64/Release ^
	/d:sonar.scm-stats.tfs.mountpath=E:\Development\Radiant\Main\. /d:sonar.scm.url=scm:tfs:http://bhiabztfs01:8080:JewelSuite:$/Radiant/Main ^
	/d:sonar.mscover.vstest.inisolation=true /d:sonar.resharper.inspectcode.properties=VisualStudioVersion=14.0 ^
	/d:sonar.resharper.inspectcode.cacheshome=E:\Development\Radiant\Main\InspectCode\Cache\. ^
	/d:sonar.resharper.usecache=true /d:sonar.mscover.workspace=E:\Development\Radiant\Main\. ^
	/d:sonar.cs.fxcop.dictionaryPath=E:\Development\Radiant\Main\Build\CustomDictionary.xml
"C:\Program Files (x86)\MSBuild\14.0\bin\msbuild.exe" /p:RunCodeAnalysis=true /verbosity:quiet /clp:NoSummary;NoItemAndPropertyList;ErrorsOnly  /p:Platform=x64 /p:Configuration=Release
"C:\Program Files\SonarQube\MSBuild.SonarQube.Runner.Exe" end
