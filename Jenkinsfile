node {
	checkout scm
	
	stage('Sonar-Scan') {			
		if (env.BRANCH_NAME != 'master') {
			if (env.BRANCH_NAME.startsWith('PR-')) {
				withSonarQubeEnv('TerraTex SonarQube') {
					sh "${tool 'SonarQubeScanner'}/bin/sonar-scanner -Dsonar.projectVersion=${BUILD_DISPLAY_NAME} -Dsonar.analysis.mode=preview -Dsonar.github.pullRequest=${BRANCH_NAME:4} -Dsonar.github.oauth=9772de9ea5c38a784defd722e2b1b428c1d50000 -Dsonar.github.repository=TerraTex-Community/HTMP-Real--Roleplay-Script"
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
