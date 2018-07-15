![alt text](https://cdn-images-1.medium.com/max/1600/1*hGJHnXJuOmfjIcEofbC0Ww.png 'Ambrosus')

# Ambrosus C# SDK (Designed for Windows IoT and .NET core applications)

Library for simple interaction with Ambrosus API for C# Applications.

## Overview

- [Prerequisite](#prerequisite)
- [Usage](#usage)
- [Ambrosus SDK methods](#ambrosus-sdk-methods)
  - [Get asset](#get-asset)
  - [Get assets](#get-assets)
  - [Create asset](#create-asset)
  - [Get event](#get-event)
  - [Get events](#get-events)
  - [Create event](#create-event)
  - [Node](#node)
- [Examples](#examples)

## Prerequisite

In order to use Ambrosus SDK, first you _need to have a developers account_.\
You can [apply for one here](https://selfservice-test.ambrosus.com/create).

- Visual Studio 2017


### Download

```
git clone https://github.com/asebak/amb-windowsiot.git
```
Open AmbWindowsIoT\AmbWindowsIoT.sln


## Usage

Initialize the Ambrosus library.\
In the script on your page where you use Ambrosus SDK, put this code in the beginning of the script:

```csharp
            var sdk = new AmbrosusSdk(new AmbrosusSettings
            {
                ApiEndpoint = "https://gateway-test.ambrosus.com",
                Address = "",
                Secret = ""
            });
```

If only reading data, then the secret and address are not required.


## Ambrosus SDK methods

## Assets

### GET asset

Returns the data of a specific asset.

```csharp
     Asset asset = sdk.GetAssetById("0xc0cdb3f2b81d928369de4143cdb1a20e5ecdec09e0ea123dd828bdcc55a048db");
```

---

### GET assets

Returns array of assets.\
For this method you can apply certain filters.

```csharp
            AssetList assets = sdk.GetAssets(new AssetOptions
            {
                PerPage = 10,
                Page = 4
            });
```

---

### CREATE asset

Create a new asset.


Example for assetData:

```csharp
           Asset asset = sdk.CreateAsset();
```

## Events

### GET event

Returns the data of a specific event.


```csharp
            Event eve = sdk.GetEventById("0xc0cdb3f2b81d928369de4143cdb1a20e5ecdec09e0ea123dd828bdcc55a048db");

```

---

### GET events

Returns array of events.\
For this method you can apply certain filters.


```csharp
      EventList events = sdk.GetEvents(new EventOptions
            {
                PerPage = 10
            });
```

---

## CREATE event

Create new event given an asset id.


```csharp
            sdk.CreateEvent("0x..4342323", new List<Datum>
            {
                new Datum
                {
                    Type = EventType.Info.Value,
                    AdditionalData = new Dictionary<string, JToken>
                    {
                        {
                            "name",
                            "PURE DARK CHOCOLATE BAR 92%"
                        },
                        {
                            "size",
                            "2.64 oz."
                        }
                    }
                }
            });

```

## Node

Get information about the node network being used.

```csharp
            var nodeinfo = sdk.GetNodeInfo();
            Console.WriteLine(nodeinfo.NodeAddress);
            Console.WriteLine(nodeinfo.Version);

```

## Examples

Coming soon
