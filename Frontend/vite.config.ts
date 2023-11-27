import { UserConfig, defineConfig } from 'vite'
import { spawn } from 'child_process'
import fs from 'fs'
import path from 'path'

const certificateName = process.env.npm_package_name

const baseFolder = process.env.USERPROFILE
  ? `${process.env.USERPROFILE}/ASP.NET/https`
  : `${process.env.HOME}/.aspnet/https`

const certFilePath = path.join(baseFolder, `${certificateName}.pem`)
const keyFilePath = path.join(baseFolder, `${certificateName}.key`)

export default defineConfig(async () => {
  // Ensure the certificate and key exist
  if (!fs.existsSync(certFilePath) || !fs.existsSync(keyFilePath)) {
    // Wait for the certificate to be generated
    await new Promise<void>((resolve) => {
      spawn(
        'dotnet',
        [
          'dev-certs',
          'https',
          '--export-path',
          certFilePath,
          '--format',
          'Pem',
          '--no-password'
        ],
        { stdio: 'inherit' }
      ).on('exit', (code) => {
        resolve()
        if (code) {
          process.exit(code)
        }
      })
    })
  }

  // Define Vite configuration
  return {
    appType: 'custom',
    root: 'src',
    build: {
      emptyOutDir: true,
      manifest: true,
      copyPublicDir: true,
      outDir: '../../wwwroot',
      assetsDir: '',
      rollupOptions: {
        input: [
          'src/bounty_actions.ts',
          'src/game.ts',
          'src/jquery.ts',
          'src/main.ts',
          'src/theme_switcher.ts'
        ]
      }
    },
    server: {
      strictPort: true,
      https: {
        cert: certFilePath,
        key: keyFilePath
      }
    },
    optimizeDeps: {
      include: []
    }
  } satisfies UserConfig
})
