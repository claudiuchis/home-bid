pipeline {
    agent none
    stages {
        stage('Test') {
            agent {
                dockerfile {
                    filename 'Dockerfile'
                    dir 'Src/e2e'
                    label 'homebid-e2e-test'
                }
            }
            steps {
                sh 'dotnet test'
            }
        }
    }
}