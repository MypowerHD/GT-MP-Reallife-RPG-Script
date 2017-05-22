pipeline {
  agent any
  
	stage('Deploy Dev') {	
		steps {
			when {
                branch 'develop'
            }
                echo 'Deploying dev'
            }
		}
	}
	stage('Deploy Master') {
		steps {
			when {
                branch 'master'
            }
                echo 'Deploying master'
            }
		}
	}
	
}