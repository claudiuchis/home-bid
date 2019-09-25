pipeline {
    agent none
    stages {
        stage('Bidding.API') {
            agent {
                dockerfile {
                    filename 'Bidding.Dockerfile'
                    // dir 'Src/e2e'
                }
            }
            steps {
                // sh 'cat /results/results.xml'
            }
        }
    }
}