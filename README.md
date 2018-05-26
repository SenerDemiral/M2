# M2
Communication between WinClients and StarcounterDB via gRPC.

Rest (ClassLibrary): gRPC (+protobuf) auto genereated classes, used by RestClient and RestServer.

RestServer (ConsoleApp): gRPC Server implementation that only sends 10,000 records if requested.

RestServerSC (StarcounterApp): same as RestServer but retrieve data from StarcounterDB.

RestClientWinForm (WinForms): Send request to RestServer (SelectTbla) and fill the DataSet.Table with replied objects (TblaRec).

ML2DB (StarcounterClassLibrary): to share DB tables.

ML2 (StarcounterApp): Proposed Starcounter App UI. It is empty now.

protos/rest.proto: gRPC service definitions and protobuf message definitions.

generate_protos.bat: Creates Rest.cs and RestGrpc.cs (in Rest directory) from protos/rest.proto file.
