# LDG AT-1000 ProII Control Program

This is my attempt to reverse-engineer the LDG AT-1000ProII Meter protocol in order to eventually implement software control AND meter reading. It's very much a work in progress, so no judging.

To communicate with the tuner, I needed a USB to TTL virtual serial adapter. The TTL is important, the voltages are different than for RS-232. Fortunately, the USB adapter I acquired takes care of all the level shifting for me. If you want to use an RS-232 port, you need to make or buy a level shifter to convert from 12V RS-232 to 5V TTL. A suitable item can be found on Amazon if you search for "FTDI USB TTL Adapter."

The other thing you need is a 4 PIN mini-DIN connector. These are terribly hard to find, but mouser has one [here](https://www.mouser.com/ProductDetail/Kycon/KMDLAX-4P?qs=sGAEpiMZZMsPDM5321osT7ZY%252bEpo2V%252bd). Note that S-Video cables, while having the same connector, cannot be used because they bridge some of the pins together. In fact, you should NEVER use an S-Video cable with your tuner, becasue one of the pins on the tuner is +12V and you don't want that getting fed back into someplace it doesn't belong. Also, do NOT get the 4-pin connector from Amazon - they tend to melt.

LDG published a document called "meter protocol" for the LDG M-1000, which, due to it seeming to suddenly want to vanish, I have included in my repository. Much of my information for this project came from there.

## Undocumented Commands

Besides the ones documented in the Meter Protocol document, I discovered 2 additional important commands:

S - places the tuner into "meter mode," which enables it to send the meter telemetry described in the next section.

X - places the tuner back into "control mode," which turns off meter telemetry. 

[blank space] - wake up the tuner before sending it any commands.

Placing the tuner in "control mode" prior to issuing a command makes it much easier to parse command responses that come back from the tuner.

These commands don't have any responses, althought the "wake" command does cause a bunch of meter telemetry to be sent when in meter mode.

## Meter Telemetry

The data that comes from the LDG Tuner as intended for the M-1000 meter follows a certain format that looks kind of like this:

```
2 bytes representing forward power
2 bytes representing reflected power
2 bytes of something I can't discern, but it varies by band / frequency
2 byte End Of Message marker, always 0x3b3b or ";;"
```

Note that all values come across in Network Byte Order, so if you're on a little-endian machine like me, you have to do something to convert each 2-byte value. The htons() function works fine for this on Linux, but the .NET equivalent screws things up royally. I ended up reversing the bytes by hand. Thanks for nothing, Micro$cheize.

## Command Protocol

To send any command and have the tuner parse it properly, I found that you need to send a wake command first, followed by a 1ms delay before sending the actual desired command. Additionally, if the tuner is in meter mode, it is a good idea to send a  "control mode" command first before sending the desired command.  Examples of this can be found in the source code.

## Linux version

I made a linux version of this code that's very stripped down and only runs on the command line. It's up here on GitHub somewhere...

## NEW - Remote Operation

You can now connect to a socat server running on a remote machine to control each device over TCP/IP. Check out my [socat_server](https://github.com/efpophis/socat_server) repo for further info.

## NEW - Flex 6000 series integration

The program now has a rudimentary capability to discover a Flex 6000 series radio on your network and trigger the Flex's "transmit tune" functionality when you use Memory Tune or Full Tune. One-stop tuning for flex users, yay!


## Ardugnome edit (November 2022)
- add band display based on the 2 WTF bytes previously unknown
- changed font and reorganized form layout
- added PS supply voltage selection under the File menu. This is used to accurately calculate power output based on your input voltage to the LDG tuner.
- removed code signing
- added modification note to the About page
- amplifier connection functionality not tested, assumed working in the previous version.

## Known Issues
- These should all be resolved now. Let me know if you see them in the latest release.
- ~~when using peak mode, sometimes meter reading does not revert to zero after rf power is removed (i.e. transmission stopped). This can give the impression that there is still power being transmitted, when in fact it is not. No issues found when not using peak reading~~.
- ~~you may have to press the button twice for a function to take effect. It happens occasionally and is not repeatable~~.
- Issues will now be tracked on the [Issues](https://github.com/Efpophis/LDGControl/issues) tab.

