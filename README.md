I needed a way to peek at a remote database where I only had FTP access to the web server. This library is intended to be reusable in a web application with minimal footprint.

### Summary of requirements

* Works with legacy MySQL database (5.x) and .Net 4
* Read and display table information
* Read data
* Can execute SQL commands such as `CREATE TABLE schema.table_name`

### Table Names

Under the hood this is running the following select:

```sql
SELECT table_name 
FROM information_schema.tables 
WHERE table_type = 'base table'
AND table_schema=@tableSchema;
```

Then in your code use as follows:

```c#
using DbPeek;

var connectionString = ConfigurationManager.ConnectionStrings["ConnMySql"].ConnectionString;
var schema = "hoecs";

litTableNames.Text = new Peek(connectionString).TableNames(schema);
```

### Execute Command

Crudely execute a SQL command, example:

```sql
CREATE TABLE `hoecs`.`customers_hoe` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `customers_id` INT NULL,
  `users_id` INT NULL,
  `insert_date` DATETIME NULL DEFAULT NOW(),
  PRIMARY KEY (`id`));
```

Then in your code use as follows:

```c#
using DbPeek;

var connectionString = ConfigurationManager.ConnectionStrings["ConnMySql"].ConnectionString;

new Peek(connectionString).ExecuteCommand(commandToRun.InnerText);
```

