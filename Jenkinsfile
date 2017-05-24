node('master'){
	checkout scm
	
	stage('Sonar-Scanner') {			
		if (env.BRANCH_NAME != 'master') {
			if (env.BRANCH_NAME.startsWith('PR-')) {
				withSonarQubeEnv('TerraTex SonarQube') {
					sh "${tool 'SonarQubeScanner'}/bin/sonar-scanner -X -Dsonar.projectVersion=${BUILD_DISPLAY_NAME} -Dsonar.analysis.mode=preview -Dsonar.github.pullRequest=${CHANGE_ID} -Dsonar.github.oauth=${github_oauth} -Dsonar.github.repository=TerraTex-Community/GTMP-Real--Roleplay-Script"
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

node('windows') {	
	checkout scm
	
	stage('Build') {
		if (env.BRANCH_NAME == 'master' || env.BRANCH_NAME == 'develop') {
			bat 'nuget install resources/TerraTex-RL-RPG/packages.config -OutputDirectory resources/packages'
			bat 'msbuild resources/TerraTex-RL-RPG/TerraTex-RL-RPG.csproj'
			archiveArtifacts artifacts: '**/*.*'
		}
	}
}

node('master') {
	stage('Deploy') {
		if (env.BRANCH_NAME == 'master') {
		
			sh 'sed -i -- \'s/9090/9091/g\' resources/LocalTelnetAdmin/meta.xml'
		
			sh 'ssh root@terratex.eu "rmdir \\"D:/TerraTex/Spiele/GTMP/01_server/live/resources\\" /s /q"'
			sh 'ssh root@terratex.eu "mkdir \\"D:/TerraTex/Spiele/GTMP/01_server/live/resources/TerraTex-RL-RPG\\""'
			sh 'scp -r ./resources/TerraTex-RL-RPG root@terratex.eu:"D:/TerraTex/Spiele/GTMP/01_server/live/resources"'
			sh 'scp -r ./resources/LocalTelnetAdmin root@terratex.eu:"D:/TerraTex/Spiele/GTMP/01_server/live/resources"'
			
			sh 'ssh root@terratex.eu "xcopy \\"D:/TerraTex/Spiele/GTMP/02_configs/live\\" \\"D:/TerraTex/Spiele/GTMP/01_server/live/resources/TerraTex-RL-RPG/Configs\\" /E /Y /I"'
			sh 'ssh root@terratex.eu "xcopy \\"D:/TerraTex/Spiele/GTMP/03_shared_packages\\" \\"D:/TerraTex/Spiele/GTMP/01_server/live/resources\\" /E /Y /I"'
			
		} else if (env.BRANCH_NAME == 'develop') {
			sh 'ssh root@terratex.eu "rmdir \\"D:/TerraTex/Spiele/GTMP/01_server/dev/resources\\" /s /q"'
			sh 'ssh root@terratex.eu "mkdir \\"D:/TerraTex/Spiele/GTMP/01_server/dev/resources/TerraTex-RL-RPG\\""'
			sh 'scp -r ./resources/TerraTex-RL-RPG root@terratex.eu:"D:/TerraTex/Spiele/GTMP/01_server/dev/resources"'
			sh 'scp -r ./resources/LocalTelnetAdmin root@terratex.eu:"D:/TerraTex/Spiele/GTMP/01_server/dev/resources"'
			
			sh 'ssh root@terratex.eu "xcopy \\"D:/TerraTex/Spiele/GTMP/02_configs/dev\\" \\"D:/TerraTex/Spiele/GTMP/01_server/dev/resources/TerraTex-RL-RPG/Configs\\" /E /Y /I"'
			sh 'ssh root@terratex.eu "xcopy \\"D:/TerraTex/Spiele/GTMP/03_shared_packages\\" \\"D:/TerraTex/Spiele/GTMP/01_server/dev/resources\\" /E /Y /I"'
		}
	}

}
