I needed a way to peek at a remote database where I only had FTP access to the web server. This library is intended to be reusable in a web application with minimal footprint.

**Summary of requirements**

* Works with legacy MySQL database (5.7x) and .Net 4
* Read and display schema information
* Read data
* Can execute SQL commands such as `CREATE TABLE schema.table_name`

