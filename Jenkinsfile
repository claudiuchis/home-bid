pipeline {
    agent none
    stages {
        // stage('Bidding.API') {
        //     agent {
        //         dockerfile {
        //             filename 'Bidding.Dockerfile'
        //             // dir 'Src/e2e'
        //         }
        //     }
        //     steps {
        //         echo 'Bidding.API - Completed'
        //     }
        // }
        // stage('Integration.Test') {
        //     agent {
        //         dockerfile {
        //             filename 'Integration.Dockerfile'
        //             args '--network pg_localnet -e ConnectionString="Server=sql-bidder;Database=bidit;User Id=bidder;Password=l1ttlef1nger"'
        //         }
        //     }
        //     steps {
        //         sh 'dotnet test ./test/AcceptanceTests --results-directory /results --logger "trx;LogFileName=results.xml"'
        //         sh 'cat /results/results.xml'
        //     }
        // }
        stage ('Integration.Test') {
            agent {
                node {
                    def pgImage = docker.build("pg", "./setup/Docker/pg")
                    def testImage = docker.build("test", "./Integration.Dockerfile")

                    docker.image('pg').withRun('-e POSTGRES_PASSWORD=rand0mna1l -e APP_USER=bidder -e APP_PASSWORD=l1ttlef1nger -e APP_DB=bidit') { c-> 
                        docker.image('pg').inside('--link ${c.id}:sql-bidder')
                        {
                            sh 'while ! pg_isready; do sleep 1; done'
                        }

                        docker.image('test').inside('--link ${c.id}:sql-bidder -e ConnectionString="Server=sql-bidder;Database=bidit;User Id=bidder;Password=l1ttlef1nger"')
                        {
                            sh 'dotnet test ./test/AcceptanceTests --results-directory /results --logger "trx;LogFileName=results.xml"'
                            sh 'cat /results/results.xml'
                        }
                    }
                }
            }
            steps {
                echo 'Integration testing'
            }
        }

    }
}