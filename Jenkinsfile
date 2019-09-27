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
        stage('Integration.Test') {
            agent {
                dockerfile {
                    filename 'Integration.Dockerfile'
                    args '--network localnet'
                }
            }
            steps {
                sh 'dotnet test ./test/AcceptanceTests --results-directory /results --logger "trx;LogFileName=results.xml"'
                sh 'cat /results/results.xml'
            }
        }
    }
}