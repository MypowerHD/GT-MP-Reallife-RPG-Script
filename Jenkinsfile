pipeline {
  agent any
  
	stage('Deploy Dev') {	
		steps {			
			if (env.BRANCH_NAME == 'master') {
				echo 'master'
			} else {
				echo 'develop'
			}
		}
	}
}