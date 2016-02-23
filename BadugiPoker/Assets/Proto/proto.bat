protoc --java_out=./java badugiPokerProtoModel.proto
protogen -i:badugiPokerProtoModel.proto -o:badugiPokerProtoModel.cs -ns:com.inkstd.badugi.model