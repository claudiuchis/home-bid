#!/bin/sh
set -e

psql -v ON_ERROR_STOP=1 --username postgres <<-EOSQL
    CREATE USER $APP_USER WITH PASSWORD '$APP_PASSWORD';
    CREATE DATABASE $APP_DB;
    GRANT ALL PRIVILEGES ON DATABASE $APP_DB TO $APP_USER;
EOSQL

unset APP_USER APP_DB APP_PASSWORD