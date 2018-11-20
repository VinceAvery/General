# Order Manager Frequently Asked Questions (FAQ)

## Where is Version 1? Where is V1?
V1 - https://www52.v1host.com/SimCorpAS15/Default.aspx?menu=TeamRoomsPage

## Where is the A Team board?
A Team Board - https://www52.v1host.com/SimCorpAS15/TeamRoom.mvc/Show/17673

Slack channel - https://simcorp.slack.com/messages/C2X3EFZKK

## Where is the Team America board?
Team 'Merca Board - https://www52.v1host.com/SimCorpAS15/TeamRoom.mvc/Show/17674

Slack channel - https://simcorp.slack.com/messages/C2UT99SBU

## Where is the Under Siege board?
Under Siege Board - https://www52.v1host.com/SimCorpAS15/TeamRoom.mvc/Show/17676

Slack channel - https://simcorp.slack.com/messages/C2WPAPNG2

## Where is the WOMM board?
WOMM Board - https://www52.v1host.com/SimCorpAS15/TeamRoom.mvc/Show/17675

Slack channel - https://simcorp.slack.com/messages/C32000SQZ

## Where is the Om Nom board?
Om Nom Board - https://www52.v1host.com/SimCorpAS15/TeamRoom.mvc/Show/17670

Slack channel - https://simcorp.slack.com/messages/C6GBWMK96

## Which Slack channels does Order Manager use?
Many. Try clicking the word 'Channels' in the Slack left menu, and it takes you to a dialogue entitled Browse Channels. Most of the Order Manager channels start with 'om-'.

## Can I request software to be installed on my machine?
The self service software installation page can be found here: http://software/portal/

Another link - https://simcorp.lightning.force.com/lightning/n/BMCServiceDesk__Remedyforce_Self_Service

## How do I request a patch apply to an environment?
The self service patch apply page can be found here: http://envtools/PatchApply/Create

## How can I see if a CR has been patched to a given installation?
CRs can be tracked in branches here http://pdscmreporting:8080/sysrep/cms_api.get_cr_branch_info?v_chgreqno=

To see if a CR has been promoted check the Patches tab on the CR in Siebel.

It is also possible to use an APL function called `CHGINCNO` to track CRs.

## How can I check if a CR is blocking?
The blocking report should do the trick - http://siebel.simcorp.int/analytics/saw.dll?Dashboard

## Where are the Order Manager specs / specifications?
The OM specs appear to be here. https://simcorp.sharepoint.com/sites/226/cfs/rm/rl/Forms/AllItems.aspx?RootFolder=%2Fsites%2F226%2Fcfs%2Frm%2Frl%2FSupplementing%20Documents%2FTrading&View=%7BC3BF544B%2D47B0%2D4BF8%2DBA5E%2D8BF2F2D4DE63%7D

## I need to setup a new PC for Order Manager development. Where is the link?
To setup a new PC for OM development https://simhub.simcorp.com/SimCorp/om-tools/blob/master/MACHINESETUP.md

## Where is GitHub / SimHub? 
The SimCorp GitHub site can be found here https://simhub.simcorp.com.

Commonly used repositories for Order Manager are:

MOMGA Server - https://simhub.simcorp.com/SimCorp/om-server

Classic Order Manager - https://simhub.simcorp.com/SimCorp/OrderManager

Broker Axes - https://simhub.simcorp.com/SimCorp/om-broker-axes

Order Manager Tools - https://simhub.simcorp.com/SimCorp/om-tools

Details on Git usage and GitFlow implementation can be found here
https://simhub.simcorp.com/SimCorp/OrderManager/blob/master/Docs/GitFlow/GitFlowFAQs.md

## Where is TFS?
TFS http://tfsprod:8080/tfs

## Where is Team City?
Team City http://teamcity/

## Where is the MOMGA repository?
MOMGA Server - https://simhub.simcorp.com/SimCorp/om-server

MOMGA Updater - https://simhub.simcorp.com/SimCorp/om-momga-updater

MOMGA Events Explorer - https://simhub.simcorp.com/SimCorp/om-orderevents-explorer

The MOMGA server code is built here: http://teamcity/project.html?projectId=SimHub_Momga&tab=projectOverview
The MOMGA Event Explorer is built here: http://teamcity/project.html?projectId=SimHub_OrderEventsExplorer&tab=projectOverview

Slack channel - https://simcorp.slack.com/messages/G30KMQLDS

## Where is the Order Manager GIT repository / Order Manager repository / OM Repo / OM Repository?
OM Repository - https://simhub.simcorp.com/SimCorp/OrderManager

## Where is the Broker Axes GIT repository?
The Broker Axes code can be found here - https://simhub.simcorp.com/SimCorp/om-broker-axes

The code is built here - http://teamcity/project.html?projectId=SimHub_BrokerAxes&tab=projectOverview

## Where is the Order Manager Tools GIT repository?
The OM Tools code can be found here - https://simhub.simcorp.com/SimCorp/om-tools

The code is built here - http://teamcity/viewType.html?buildTypeId=SimHub_Tools_OmToolsBuild

## Where is OMConsole?
The OM Console can be found here - https://simhub.simcorp.com/SimCorp/om-tools/tree/master/Tools/OMConsole

## Where is Merge Monkey?
The Merge Monkey code can be found here - https://simhub.simcorp.com/SimCorp/om-merge-monkey

The code is built here - http://teamcity/viewType.html?buildTypeId=SimHub_Tools_MergeMonkeyBuild

Monkey runs on this machine and the logs are here - file://dk01wv2000/c$/MergeMonkey/MergeMonkey.log

## Which CR does MergeMonkey use to patch to closed version / Merge Monkey CR??
Merge Monkey CR is CR588662

## Where is OMConsistency / OM Consistency?
The OMConsistency code can be found here - https://simhub.simcorp.com/SimCorp/om-consistency
The code is built here - http://teamcity/viewType.html?buildTypeId=SimHub_Tools_OMConsistencyBuild

## How is the Order Manager NuGet package created?
The OM Nuget is created in the FAKE script. The logic is scripted using APL calls
See this repo - https://simhub.simcorp.com/SimCorp/om-vcs-registration
Invoked from TeamCity - http://teamcity/viewType.html?buildTypeId=SimHub_OrderManager_DeployToVCS

## Where is the SimCorp NuGet Server? (Proget)
It SimCorp NuGet server is here - http://proget.tools.scdom.net/packages

## Where is the Order Manager development documentation / OM dev docs?
The OM developer documentation is here: https://simhub.simcorp.com/SimCorp/OrderManager/tree/master/Docs

Older documentation can be found on the Wiki under the category 'OM3' - https://wiki/index.php?title=Category:OM3

## How do I setup my global configuration?
The global configuration can be found here. It should be copied to C:\ProgramData\Order Manager\<Version> e.g. C:\ProgramData\Order Manager\6.41

https://simhub.simcorp.com/SimCorp/om-tools/tree/master/Standalone/GlobalConfiguration

## How do I turn on Tracing in Order Manager?
See this page to turn on tracing - it should help https://wiki/index.php?title=Tracing_in_Order_Manager

## How do I create a new IMS service?
To create an IMS service, see this page - it should help https://simhub.simcorp.com/SimCorp/OrderManager/blob/master/Docs/ServiceCreation/How-to-create-a-new-service.md

## What Order Manager code changes are required for moving to a new version?
When moving to a new version, see this page - it should help 
https://simhub.simcorp.com/SimCorp/OrderManager/blob/master/Docs/Updating%20OM%20Version.md

## How do I upgrade the version of the C# compiler for Order Manager?
This pull request has a good example of upgrading the C# compiler.
https://simhub.simcorp.com/SimCorp/OrderManager/pull/3550

## How do I upgrade Oracle Version for Order Manager?
See this page to Upgrade Oracle version - it should help https://simhub.simcorp.com/SimCorp/OrderManager/blob/1ec5953b56ab45f09f15bcd493258413b5e54928/Docs/Upgrade%20Oracle.md

See Git commit 18f7f8be for guidance.

## How do I upgrade FPML version in Order Manager?
See this page for details on upgrading FPML - it should help https://simhub.simcorp.com/SimCorp/OrderManager/blob/1ec5953b56ab45f09f15bcd493258413b5e54928/Docs/Upgrade/Upgrade%20FPML%20Version.md

## How do I upgrade .NET Version for Order Manager?
Update .NET version - change the props - https://simhub.simcorp.com/SimCorp/OrderManager/blob/master/Directory.Build.props

See GIT commit e6a288c3

## How do I upgrade DevExpress for Order Manager?
To upgrade DevExpress version, see Git commit 2e15c78f

## How do I make a change to Entity Framework?
To make changes to Entity framework, see Wiki page https://wiki/index.php?title=Entity_Framework_for_Oracle

This pull request should give some help https://simhub.simcorp.com/SimCorp/OrderManager/pull/2691

## Where is the latest Sellside Simulator?
The Sellside Simulator code can be found here - https://simhub.simcorp.com/SimCorp/om-sellsidesimulator
 
The code is built here - http://teamcity/viewType.html?buildTypeId=SimHub_Tools_SellsideSimulator

The slack channel is here - https://simcorp.slack.com/messages/C704KT3HU

Neil Sumpter (@NSP) occasionally builds the SSS installer and copies it here - F:\SSS

It can be started using the command SSS in OMConsole, which does not require the SSS installer.

## Where is the latest FIX.NET Server (FNS)?
The FIX.NET Server code can be found here - http://tfsprod:8080/tfs/IMS%20Collection/Development/_versionControl#path=%24%2FDevelopment%2FTracks%2FIMPL%2FFIX.NET+Server&_a=contents

The code is built here using CruiseControl not Team City - http://dk01sv0424/ViewFarmReport.aspx

The slack channel is here - https://simcorp.slack.com/messages/C6ZNS94HJ

Neil Sumpter (@NSP) occasionally builds the FNS installer and copies it here - F:\FIX\CandidateReleases

More details on the FNS build server - https://wiki/index.php?title=FIX.NET_Server_5.x_Build_Environment

More details on FNS: https://wiki/index.php?title=FIX.NET_Server_Home

This tool FIXer is excellent for setting up FIX sessions in development - https://simhub.simcorp.com/SimCorp/om-tools/tree/master/Tools/FIXer

## How do I upgrade FIX.NET Server?
Copy the latest version from F:\FIX\CandidateReleases. Run the command upgrade_fns in Powershell. That's all.

## How do I upgrade the Sellside Simulator?
If running from OMConsole, you will always have the latest Sellside Sim source.

If using the installer, run the latest from F:SSS and it should remove the old version and add the new version.

## How do I install Elvin?
See the Elvin section here - https://simhub.simcorp.com/SimCorp/om-tools/blob/master/MACHINESETUP.md

Or there are more scripts here - https://simhub.simcorp.com/SimCorp/om-tools/tree/master/Standalone/Elvin

## How do I setup the dark pool simulator?
The code and docs for the dark pool simulator can be found here - https://simhub.simcorp.com/SimCorp/om-tools/tree/master/Tools/DarkpoolSimulator

## How do I check if code has been deployed to an environment? (Environment checker)
Environment Checker status page: http://dk01wv2000.scdom.net:8080

The code can be found here - https://simhub.simcorp.com/SimCorp/om-environment-status

## How do I create a new Order Manager Oracle database?
To create an Oracle database for OM, see this page - it should help https://simhub.simcorp.com/SimCorp/om-tools/tree/master/Standalone/Database

## How do I patch an Order Manager Oracle database?
To patch an Oracle database for OM, see this page - it should help https://simhub.simcorp.com/SimCorp/om-tools/tree/master/Standalone/Database

## How do I add/delete/update an assembly in Order Manager classic?
For OM assembly management, see these pages - https://simhub.simcorp.com/SimCorp/OrderManager/tree/master/Docs/VCSRegistration

## How do I setup connectivity to trading platforms in my development environment?
To setup connectivity to trading platforms, this doc should help:

https://simhub.simcorp.com/SimCorp/OrderManager/blob/45600639dad4683dc3a80b2888524003f132a847/Docs/Setup%20Trading%20Platforms%20for%20Development.md
 
## How do I generate a list of internal SCD database connection strings?
To generate a list of internal SCD DB connections strings, use this tool - https://simhub.simcorp.com/SimCorp/om-tools/tree/master/Tools/SQLDeveloperConfigGenerator

## How can I monitor Elvin traffic using the Elvin eScanner tool?
The code for the Elvin eScanner can be found here
https://simhub.simcorp.com/SimCorp/om-tools/tree/master/Tools/ElvinSandbox/SimCorp.IMS.OM.Tools.ElvinScanner

## Where are the integrated test environments?
All the shortcuts to the test environments are on the T drive.

OM is setup in dev in FO-ART-P - \\dk01sn008\SC Dimension Shortcuts\SCD Dev\FOART-P

In closed version, the OM environment is usually named TEST_OM3 e.g. \\dk01sn008\SC Dimension Shortcuts\SCD 6.41\TEST_OM3

## What is the FIX Platform Tester?
The FIX platform tester uses FIX test sessions to connect to FIX trading platforms. This happens on a daily basis (Mon to Fri) and ensures that the test sessions remain active.

The code can be found here: https://simhub.simcorp.com/SimCorp/om-tools/blob/master/Scripts/Test-ExternalFixSessionsForPlatforms.ps1

The script it setup to run on machine dk01wv2198.

## Where can I find sample ATDL strategy files?
Sample ATDL strategy files are here. They probably should be moved to SimHub.

http://tfsprod:8080/tfs/IMS%20Collection/Development/_versionControl#path=%24%2FDevelopment%2FProjects%2FFIXatdl+Strategy+Files%2FFIXatdl+v1.1%2FCurrent+Files%2FBroker&_a=contents

## How do XSL config overrides work?
The repository for client configuration overrides can be found here:

https://simhub.simcorp.com/SimCorp/om-client-xslt-overrides

A tool for generating a zip of overrides per client can be found here.

https://simhub.simcorp.com/SimCorp/om-tools/tree/master/Tools/XSLTDeploy

To enable overrides in debug or an integrated environment, a folder named 'Order Manager' should be manully created one level above the Bin folder. This folder should contain a file called ConfigurationGUID.config containing the GUID for this release, along with a folder structure mirroring the XSL paths. The first folder should be SimCorp. e.g. OrderManager\SimCorp\IMS\OM\Services\Orders\Configuration\Gateway\Inbound

## Do the IMS code generators run in the Order Manager build process?
Yes they do. Look in the definition project for a service e.g. https://simhub.simcorp.com/SimCorp/OrderManager/blob/aecee5fb770602ba3e960bf4c02005c185d0d9ab/OM/Services/Orders/Service/Definition/IMS.OM.Services.Orders.Service.Definition.csproj
 
<Target Name="GenerateServiceCode" AfterTargets="ResolveAssemblyReferences">
 <SimCorp.IMS.CodeGenerators.Framework.Service.Design.ServiceCodeGenerator InputFilename="$([System.IO.Path]::Combine($(ProjectDir), 'OrderService.ServiceModel'))" GenerateType="All" References="@(Reference);@(_ResolvedProjectReferencePaths)" OutputPath="$(OutputPath)" />
  </Target>

## When do the OM repositories update?
This document details the update frequency for all OM repositories https://simhub.simcorp.com/SimCorp/OrderManager/blob/master/Docs/Standalone%20vs.%20Integrated%20Modes.md

## What should I know about database conversion programs (CBUs)?
CBUs - https://wiki/index.php?title=Index_for_Conversion_and_CBU_documentation

## Where is OpenGrok?
OpenGrok allows for fast code indexing and searching.
The FOART-P branch is in the OpenGrok code indexing.

You can access it by following URLs (do Shift+Refresh on the pages in browser in order to refresh the browser’s cache): 

http://dk01su0031/

http://dk01su0031/foart-p

http://dk01su0031:8083/source/

## What APIs does Siebel have?
Here is a list of Siebel APIs http://siebintsvc/imsintsql/imsintsql.asmx

## How do I host or join a Jabber call?
To host/join a Jabber call  https://wiki/index.php?title=Joining_or_hosting_a_Jabber_call

## Where is the PIPE calendar?
The PIPE calendar can be found here. See PIPE Planning Calendar on the left. https://simcorp.sharepoint.com/sites/226/cfs/saferm/SitePages/Home.aspx

## Can I have a Pluralsight subscription for eLearning?
Yes. The best way is to start exploring the Pluralsight website (http://www.pluralsight.com/). From here you can browse the content and get an idea of the different courses that are available. If you think Pluralsight is a resource that can help you, then you should have a talk with your Development Manager and make it part of your professional development.

From the front page of the PD Learning & Development portal, you will find a link to both the Pluralsight site as well as the request form in SimPeople. (https://simcorp.sharepoint.com/sites/226/PD%20LD/Home.aspx)
