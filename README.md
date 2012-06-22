This was created as a response to a [Super User question](http://superuser.com/questions/439583/automatic-shutdown-prompt-on-windows-7).

---

The compiled version requires .NET 3.5 to run (perhaps 2.0 would work).

---

Usage is quite simple, simply execute the program, preferably in a scheduled task. It will wait the specified number of minutes before shutdown, with a window visible with options to abort/postpone. If no time is specified, it will wait 5 minutes.

    IdleShutdown.exe <minutes>

---

The notification icon [Mazenl77](http://mazenl77.deviantart.com/) is sourced from http://www.iconspedia.com/icon/shutdown-1626.html and used under the CC-BY licence
