# Configuration Guide

## Summary

This SDK uses a structure called "Config" to store and manage configuration, read ["src/Config/Config.cs"](https://github.com/dongxifu/qingcloud-sdk-net/blob/master/src/Config/Config.cs) file's comments of public functions for more information.

Except for AccessKeyID and SecretAccessKey, you can also configure the API servers for private cloud usage scenario. All available configureable items are list in default configuration file.

___Default Configuration File:___

``` yaml
# QingCloud services configuration

qy_access_key_id: 'ACCESS_KEY_ID'
qy_secret_access_key: 'SECRET_ACCESS_KEY'

host: 'api.qingcloud.com'
port: 443
protocol: 'https'
uri: '/iaas'
connection_retries: 3

# Valid log levels are "debug", "info", "warn", "error", and "fatal".
log_level: 'warn'

```

## Usage

Just create a config structure instance with your API AccessKey.

### Code Snippet

Create default configuration

``` CSharp
Config config = new Config();
```

Create configuration from AccessKey

``` CSharp
Config configanother = New Config("ACCESS_KEY_ID", "SECRET_ACCESS_KEY")

Config configanother = new Config();
config.setAccessKey("ACCESS_KEY_ID");
configanother.setAccessSecret("SECRET_ACCESS_KEY");
```

Load configuration from config file

``` CSharp
Config config = new Config();
config.loadFromFile("PATH/TO/FILE");
```

Change API server

``` CSharp
Config configanother = new Config();

config.setProtocol = "https",
config.setHost = "api.private.com",
config.setPort = 4433,
config.setURI = "/iaas",
```
