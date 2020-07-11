#!/bin/bash
set -euxo pipefail;

readonly SETUP_PATH="$PWD/setup";

echo "Starting the Initial Container Settings...";
bash "${SETUP_PATH}/setup-init.sh";

if [ $DB_MSSQL_APPLY_DATABASE = 'Y' ]; then
    echo "Starting Configuring Database in SQL Server...";
    bash "${SETUP_PATH}/setup-database.sh";
fi

if [ $DB_MSSQL_APPLY_DATABASE = 'Y' ] && [ $DB_MSSQL_APPLY_RESTORE = 'Y' ]; then
    echo "Starting Restore Database in SQL Server...";
    bash "${SETUP_PATH}/setup-restore.sh";
fi

exit $?;
