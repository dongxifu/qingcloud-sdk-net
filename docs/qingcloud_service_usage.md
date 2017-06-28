# QingCloud Service Usage Guide

Import and initialize QingCloud service with a config, and you are ready to use the initialized service.

Each API function take a Input struct and return an Output struct. The Input struct consists of request params, request headers and request elements, and the Output holds the HTTP status code, response headers, response elements and error (if error occurred).

``` CSharp
using QingCloudSDK.service;
```

### Code Snippet

Initialize the QingCloud service with a configuration

``` CSharp
Config config = new Config("access_key_id", "secret_access_key");
```

Initialize the instance service in a zone

``` CSharp
Instance intance = new Instance(config, "pek3a");
```

DescribeInstances

``` CSharp
Instance.DescribeInstancesInput input = new Instance.DescribeInstancesInput();
Instance.DescribeInstancesOutput output = new Instance.DescribeInstancesOutput();
output = intance.DescribeInstances(input);

// Print the return code.
Console.WriteLine (output.getRet_code());

// Print the first instance ID.
Console.WriteLine (output.getInstance_id()[0]);
```

RunInstances

``` go
Instance.RunInstancesInput input = new Instance.RunInstancesInput();
input.setImage_id("centos7x64d");
input.setCpu(1);
input.setMemeory(1024);
input.setLogin_mode("keypair");
input.setLogin_keypair("kp-xxxxxxxx");

Instance.RunInstancesOutput output = new Instance.RunInstancesOutput();
output = intance.RunInstances(input);

// Print the return code.
Console.WriteLine(output.getRetCode());

// Print the job ID.
Console.WriteLine(output.getJobId());
```

Initialize the volume service in a zone

``` CSharp
Config config = new Config("access_key_id", "secret_access_key");
Instance intance = new Instance(config, "pek3a");
```

DescribeVolumes

``` CSharp
Instance.DescribeVolumesInput input = new Instance.DescribeVolumesInput();
Instance.DescribeVolumesOutput output = new Instance.DescribeVolumesOutput();
output = intance.DescribeVolumes(input);

// Print the return code.
Console.WriteLine(output.getRetCode());

// Print the first instance ID.
Console.WriteLine(output.getVolomeId()[0]);
```

CreateVolumes

``` CSharp
Instance.CreateVolumesInput input = new Instance.CreateVolumesInput();
input.setSize(10);
input.setCount(2);
Instance.CreateVolumesOutput output = new Instance.CreateVolumesOutput();
output = intance.CreateVolumes(input);

// Print the return code.
Console.WriteLine(output.getRetCode());

// Print the job ID.
Console.WriteLine(output.getJobId());
```

