# M2
Accounting with Starcounter and gRPC

Directory Structure

Rest: gRPC (+protobuf) auto genereated classes, used by RestClient and RestServer.

RestServer: ConsoleApp to Serve client request. Only sends 10,000 records if requested.

RestServerSC: Starcounter App is same as RestServer but retrieve data from StarcounterDB.

RestClientWinForm: Send request to RestServer (SelectTbla) and fill the DataSet.Table with replied objects (TblaRec).

ML2DB: Starcounter Class Library to share DB tables.

ML2: Proposed Starcounter App UI. It is empty now.
