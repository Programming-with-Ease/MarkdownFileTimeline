# Design

## Solution Approach

### Obvious Functional Areas

* Compile all relevant files (e.g. all with extension `.md`)
  * possibly exclude files/directories on a *blacklist*
* Sort files by time from newest to oldest
  * possibly duplicate entries if creation and change dates are different
* Calculate stats, e.g. how many files in which date range
* Group files
  * by day
  * by week
* Paginate
* Display with interaction
  * paging
  * jumping to a day
  * opening a file

### Obvious Data Structures

* **MDFile**
  * Filename
  * Path to file
  * Number of lines in file
  * Date created
  * Date last changed
* **Day**
  * Date
  * A list of **MDFile**
* **Week**
  * Week number (1..52)
  * A list of **Day**
* **Page**
  * Formatted lines of text to display
  * List of **MDFile** represented by the page in the order they appear in the page lines

