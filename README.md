### "Mino" system administrator's help program — what is it?
The program is designed to keep track of equipment and events in an enterprise and is a database management system for SQLite. 
It can quickly select cartridges by printer model or employee name.

This is an old, very entry-level educational project in terms of implementation and it is very simple program, but it is actually used in real enterprise.

User Interface in Russian.

![flag_RU](https://github.com/pasjamais/lib_postgres/assets/123422286/8b634a7c-4815-4cca-9ed9-6fd3d972322a)

### Main features
* The “Journal” section allows to register user requests with a description of the need and the choice of the type of service provided. 
* The “Computers” section displays information about the characteristics of the PCs.
* The “Printers” section allows to work with the printer movement. It is possible to work both with a list of printer models and a list of printers. There is functionality for displaying reports related to printers, including the ability to set a parameter, for example, “the adventures of SUCH a printer” will show the history of movement of the device from office to office, for repair, etc. For this purpose For the functionality to work, it is necessary to timely reflect the movement of equipment with a corresponding entry.
* The “Cartridges” section allows to keep track of (return – issue) cartridges, work with lists of cartridge models and their storage locations, adding, changing and deleting. The section also provides work with a table of compatibility of printer models and cartridges suitable for them; such connections are called “alliances”.
* During operation, the program informs the user about what is happening by displaying messages in the lower left corner of the window.
* Each time the program is started, the database is backed up to the Backup folder (if it does not exist, the folder is created). The mino.db database file has to be located in the same directory as the program.

* ### Installation
[https://github.com/pasjamais/lib_postgres/releases](https://github.com/pasjamais/mino/releases)https://github.com/pasjamais/mino/releases

### Screenshots

Computers list:

![PCs](https://github.com/pasjamais/mino/assets/123422286/aceedf5d-85d2-480a-b182-4ee2f1043925)

Сhecking cartridge availability by user:

![cartridge_select](https://github.com/pasjamais/mino/assets/123422286/bb3bdd47-d5f6-4acc-842b-ebef669ff953)

Form of action with cartridge:

![accept_cartridge](https://github.com/pasjamais/mino/assets/123422286/8773ba8e-14a5-4693-bab8-778d08b558a9)

Query "Where are the printers now"):

![where_printers](https://github.com/pasjamais/mino/assets/123422286/96d1aa84-4602-4010-b8bd-98592fb3639d)

About the program (in Russian):

![about](https://github.com/pasjamais/mino/assets/123422286/99c7fba5-b21f-4518-acc8-234c5bb3b7d9)
