pipeline {
    agent none
    stages {
        stage('Test') {
            agent {
                dockerfile {
                    filename 'Dockerfile.test'
                    // dir 'Src/e2e'
                }
            }
            steps {
                sh 'dotnet test'
            }
        }
    }
}