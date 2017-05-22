node {
	checkout scm
	
	stage('Sonar-Scan') {			
		if (env.BRANCH_NAME != 'master') {
			if (env.BRANCH_NAME.startsWith('PR-')) {
				withSonarQubeEnv('TerraTex SonarQube') {
					sh "${tool 'SonarQubeScanner'}/bin/sonar-scanner -X -Dsonar.projectVersion=${BUILD_DISPLAY_NAME} -Dsonar.analysis.mode=preview -Dsonar.github.pullRequest=${CHANGE_ID} -Dsonar.github.oauth=${github_oauth} -Dsonar.github.repository=TerraTex-Community/GTMP-Real--Roleplay-Script"
				}
				timeout(time: 1, unit: 'HOURS') {
					def qg = waitForQualityGate()
					if (qg.status != 'OK') {
						error "Pipeline aborted due to quality gate failure: ${qg.status}"
					}
				}
			} else {
				withSonarQubeEnv('TerraTex SonarQube') {
					sh "${tool 'SonarQubeScanner'}/bin/sonar-scanner -Dsonar.projectVersion=${BUILD_DISPLAY_NAME}"
				}
				timeout(time: 1, unit: 'HOURS') {
					def qg = waitForQualityGate()
					if (qg.status != 'OK') {
						error "Pipeline aborted due to quality gate failure: ${qg.status}"
					}
				}		
			}
		}
	}
}
