pipeline {
  agent any
  
	if (env.BRANCH_NAME == 'develop') {
        stage('Deploy sitesite') {
            steps {
				echo 'Branch: develop'
			}
        }
    }
	if (env.BRANCH_NAME == 'master') {
        stage('Deploy sitesite') {
            steps {
				echo 'Branch: Master'
			}
        }
    }
	
}