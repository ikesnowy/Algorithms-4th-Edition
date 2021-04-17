using _1._3._44;

var buffer = new Buffer();
buffer.Insert('1');
buffer.Insert('2');
buffer.Insert('3');
buffer.Insert('4');

buffer.Left(2);
buffer.Delete();
buffer.Insert('5');
System.Console.WriteLine(buffer.Getstring());