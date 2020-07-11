#!/bin/bash
set -euxo pipefail;

echo "Initializing restore execution...";
# /opt/mssql-tools/bin/sqlcmd -S 0.0.0.0 -d $DB_MSSQL_DATABASE -U $DB_MSSQL_USER -P $DB_MSSQL_PASSWORD \
#                             -i ./scripts/base.sql \
#                             -i ./scripts/procedures.sql \
#                             -i ./scripts/views.sql \
#                             -i ./scripts/data.sql;

echo "Finished restore the database.";

exit $?;
