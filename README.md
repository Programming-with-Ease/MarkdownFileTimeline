# Markdown File Timeline (MFT)
Many prefer to store their notes as Markdown files in their file system. Some call that a [Zettelkasten](https://zettelkasten.de/posts/zettelkasten-improves-thinking-writing/). The tools they are using are mostly focused on editing the notes and maybe searching through them. More recent tools also provide a network view of linked notes.

But what's lacking so far is a timeline view of notes. Which notes got created (or editied) when? What's the history one's note taking?

Enter: MFT

With MFT all `.md` files in a directory tree are compiled and presented as a timeline like this:

```
$ ./mft
146 files found between 23.02.2018 and 25.08.2020

Page 1/13

Week 35--------+
Tue 25.08.2020 |  1. A note (7 lines)
               |  2. Another note (10 lines)
Mon 24.08.2020 |  3. Yet another note (8 lines)
               |  4. One more note (25 lines)
               |  5. Cannot stop writing notes (134 lines)
Week 34--------+
Sun 23.08.2020 |
Sat 22.08.2020 |  6. A wonderful note (2 lines)
Fri 21.08.2020 |  7. Even mote so (28 lines)
               |  8. Final note on this day (6 lines) @ 29.07.2020
Thu 20.08.2020 |
Wed 19.08.2020 |  9. How about this (44 lines)
Tue 18.08.2020 |
Mon 17.08.2020 |
Week 33--------+
Sun 16.08.2020 |  10. Take that (21 lines)
...
Week 31--------+
Wed 29.07.2020 | 11. Final note on this day (6 lines)

::: N(ext, P(rev, <date>, <index>: 
```

* Notes are presented starting from the most recent one group by day and week.
* The user can 
  * page through the notes, 
  * jump to a certain date, and 
  * open them with the preferred Markdown editor.
* Single days without files are still listed in the timeline, but several days (>7 days) without files will be replaced by `…`.

# Installation

1. Install .NET Core 3.1 if it's not already on your machine. Download it for all platforms [from here](https://dotnet.microsoft.com/download/dotnet-core).
2. Download the latest release ZIP-file of mft [from this repository](https://github.com/Programming-with-Ease/MarkdownFileTimeline/releases).
3. Unpack the ZIP-file where it's convenient. Maybe put it close to your note files.
4. Run the tool in a terminal/shell window: `dotnet exec mft.dll .`
   * Prepend a path to `mft.dll` if it's not in the same directory the terminal/shell is opened in.
   * Replace the `.` with a path to the root directory of your note files if they are not in the same directory as the terminal/shell is opened in.