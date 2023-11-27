export default {
  plugins: {
    autoprefixer: {},
    ...(process.env.NODE_ENV === 'production'
      ? {
          '@fullhuman/postcss-purgecss': {
            content: ['../Views/**/*.cshtml', './src/**/*.ts'],
            safelist: {
              standard: ['html', 'body'],
              deep: [/^col/, /^modal/, /^btn/]
            },
            defaultExtractor: (content) =>
              content.match(/[\w-/:]+(?<!:)/g) || []
          }
        }
      : {})
  }
}
