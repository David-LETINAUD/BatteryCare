$config = Get-Content -Path C:\BatteryCare\config.txt
$COM_port = $config.split(" ")[0]

$port= new-Object System.IO.Ports.SerialPort $COM_port,9600,None,8,one
$port.open()
$port.WriteLine("c")
$port.Close()