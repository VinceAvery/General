# Order Manager Frequently Asked Questions (FAQ)

## Where is Version 1? Where is V1?
https://www52.v1host.com/SimCorpAS15/Default.aspx?menu=TeamRoomsPage

## Where is the A Team board?
Board - https://www52.v1host.com/SimCorpAS15/TeamRoom.mvc/Show/17673

Slack channel - https://simcorp.slack.com/messages/C2X3EFZKK

## Where is the Team America board?
Board - https://www52.v1host.com/SimCorpAS15/TeamRoom.mvc/Show/17674

Slack channel - https://simcorp.slack.com/messages/C2UT99SBU

## Where is the Under Siege board?
Board - https://www52.v1host.com/SimCorpAS15/TeamRoom.mvc/Show/17676

Slack channel - https://simcorp.slack.com/messages/C2WPAPNG2

## Where is the WOMM board?
Board - https://www52.v1host.com/SimCorpAS15/TeamRoom.mvc/Show/17675

Slack channel - https://simcorp.slack.com/messages/C32000SQZ

## Where is the Om Nom board?
Board - https://www52.v1host.com/SimCorpAS15/TeamRoom.mvc/Show/17670

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
They appear to be here. https://simcorp.sharepoint.com/sites/226/cfs/rm/rl/Forms/AllItems.aspx?RootFolder=%2Fsites%2F226%2Fcfs%2Frm%2Frl%2FSupplementing%20Documents%2FTrading&View=%7BC3BF544B%2D47B0%2D4BF8%2DBA5E%2D8BF2F2D4DE63%7D

## I need to setup a new PC for Order Manager development. Where is the link?
https://simhub.simcorp.com/SimCorp/om-tools/blob/master/MACHINESETUP.md

## Where is GitHub / SimHub / Git? 
The SimCorp GitHub site can be found here https://simhub.simcorp.com.
Commonly used repositories for Order Manager are:

MOMGA Server - https://simhub.simcorp.com/SimCorp/om-server
Classic Order Manager - https://simhub.simcorp.com/SimCorp/OrderManager
Broker Axes - https://simhub.simcorp.com/SimCorp/om-broker-axes
Order Manager Tools - https://simhub.simcorp.com/SimCorp/om-tools

Details on Git usage and GitFlow implementation can be found here
https://simhub.simcorp.com/SimCorp/OrderManager/blob/master/Docs/GitFlow/GitFlowFAQs.md

## Where is TFS?
http://tfsprod:8080/tfs

## Where is Team City?
http://teamcity/

## Where is the MOMGA repository?
MOMGA Server - https://simhub.simcorp.com/SimCorp/om-server
MOMGA Updater - https://simhub.simcorp.com/SimCorp/om-momga-updater
MOMGA Events Explorer - https://simhub.simcorp.com/SimCorp/om-orderevents-explorer

The MOMGA server code is built here: http://teamcity/project.html?projectId=SimHub_Momga&tab=projectOverview
The MOMGA Event Explorer is built here: http://teamcity/project.html?projectId=SimHub_OrderEventsExplorer&tab=projectOverview

Slack channel - https://simcorp.slack.com/messages/G30KMQLDS

## Where is the Order Manager GIT repository?
Repository - https://simhub.simcorp.com/SimCorp/OrderManager

## Where is the Broker Axes GIT repository?
The code can be found here - https://simhub.simcorp.com/SimCorp/om-broker-axes
The code is built here - http://teamcity/project.html?projectId=SimHub_BrokerAxes&tab=projectOverview

## Where is the Order Manager Tools GIT repository?
The code can be found here - https://simhub.simcorp.com/SimCorp/om-tools
The code is built here - http://teamcity/viewType.html?buildTypeId=SimHub_Tools_OmToolsBuild

## Where is OMConsole?
The code can be found here - https://simhub.simcorp.com/SimCorp/om-tools/tree/master/Tools/OMConsole

## Where is Merge Monkey?
The code can be found here - https://simhub.simcorp.com/SimCorp/om-merge-monkey
The code is built here - http://teamcity/viewType.html?buildTypeId=SimHub_Tools_MergeMonkeyBuild
Monkey runs on this machine and the logs are here - file://dk01wv2000/c$/MergeMonkey/MergeMonkey.log

## Which CR does MergeMonkey use to patch to closed version?
Order Manager SimHub CR588662

## Where is OMConsistency?
The code can be found here - https://simhub.simcorp.com/SimCorp/om-consistency
The code is built here - http://teamcity/viewType.html?buildTypeId=SimHub_Tools_OMConsistencyBuild

## How is the Order Manager NuGet package created?
The OM Nuget is created in the FAKE script. The logic is scripted using APL calls
See this repo - https://simhub.simcorp.com/SimCorp/om-vcs-registration
Invoked from TeamCity - http://teamcity/viewType.html?buildTypeId=SimHub_OrderManager_DeployToVCS

## Where is the SimCorp NuGet Server? (Proget)
It is here - http://proget.tools.scdom.net/packages

## Where is the Order Manager development documentation?
Here: https://simhub.simcorp.com/SimCorp/OrderManager/tree/master/Docs
Older documentation can be found on the Wiki under the category 'OM3' - https://wiki/index.php?title=Category:OM3

## How do I setup my global configuration?
The global configuration can be found here. It should be copied to C:\ProgramData\Order Manager\<Version> e.g. C:\ProgramData\Order Manager\6.41

https://simhub.simcorp.com/SimCorp/om-tools/tree/master/Standalone/GlobalConfiguration

## How do I turn on Tracing in Order Manager?
See this page - it should help https://wiki/index.php?title=Tracing_in_Order_Manager

## How do I create a new IMS service?
See this page - it should help https://simhub.simcorp.com/SimCorp/OrderManager/blob/master/Docs/ServiceCreation/How-to-create-a-new-service.md

## What Order Manager code changes are required for moving to a new version?
See this page - it should help 
https://simhub.simcorp.com/SimCorp/OrderManager/blob/master/Docs/Updating%20OM%20Version.md

## How do I upgrade the version of the C# compiler for Order Manager?
This pull request has a good example
https://simhub.simcorp.com/SimCorp/OrderManager/pull/3550

## How do I upgrade Oracle Version for Order Manager?
See this page - it should help https://simhub.simcorp.com/SimCorp/OrderManager/blob/1ec5953b56ab45f09f15bcd493258413b5e54928/Docs/Upgrade%20Oracle.md
See Git commit 18f7f8be for guidance.

## How do I upgrade FPML version in Order Manager?

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

## 

