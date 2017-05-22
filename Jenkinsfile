if (env.BRANCH_NAME == 'develop') {
	pipeline {
		agent any
		stage('Deploy sitesite') {
			steps {
				echo 'Branch: develop'
			}
		}		
	}
}
if (env.BRANCH_NAME == 'master') {
	pipeline {
		agent any
		stage('Deploy sitesite') {
			steps {
				echo 'Branch: Master'
			}
		}
	}
}