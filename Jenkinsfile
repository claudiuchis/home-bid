pipeline {
    agent none
    stages {
        stage('Test') {
            agent {
                dockerfile {
                    filename 'Dockerfile'
                    dir 'Src/e2e'
                }
            }
            steps {
                sh 'dotnet test'
            }
        }
    }
}