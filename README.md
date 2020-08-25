# Markdown File Timeline (MDF)
Many prefer to store their notes as Markdown files in their file system. Some call that a [Zettelkasten](https://zettelkasten.de/posts/zettelkasten-improves-thinking-writing/). The tools they are using are mostly focused on editing the notes and maybe searching through them. More recent tools also provide a network view of linked notes.

But what's lacking so far is a timeline view of notes. Which notes got created (or editied) when? What's the history one's note taking?

Enter: MDF

With MDF all `.md` files in a directory tree are compiled and presented as a timeline like this:

```
$ mdf
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
Thu 20.08.2020 |
Wed 19.08.2020 |  8. How about this (44 lines)
Tue 18.08.2020 |
Mon 17.08.2020 |
Week 33--------+
Sun 16.08.2020 |  9. Take that (21 lines)
...
Week 31--------+
Wed 29.07.2020 | 10. Final note on this day (6 lines)

::: N(ext, P(rev, <date>, <index>: 
```

Notes are presented starting from the most recent one group by day and week.

The user can page through the notes and open them with the preferred Markdown editor.