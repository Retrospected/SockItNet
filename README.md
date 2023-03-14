# SockItNet

Simple .NET Framework console application to setup a TCP listener. A poor man's NetCat but it is atleast not being detected by any AV/EDR solutions.

## Usage

Start by compiling, the project is configured to be compiled for .NET Framework v4.8.1 but I am sure it will work for more versions.

Start the TCP listener:
```
.\SockItNet.exe -p <portnumber>
```

Connect using your favorite TCP client, such as:
```
nc <ip> <port>
```

And enjoy a nice conversation with yourself.

# Credits

ChatGPT. Do you really think I took the effort to write this myself?