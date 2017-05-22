node {
	stage('deplay') {			
		if (env.BRANCH_NAME == 'master') {
			echo 'master'
		} else {
			if (env.BRANCH_NAME.startsWith('PR-')) {
				echo env.BRANCH_NAME
			} else {
				echo 'develop'			
			}
		}
	}
}