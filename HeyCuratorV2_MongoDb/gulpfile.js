const gulp = require('gulp');

gulp.task('css', () => {
    const postcss = require('gulp-postcss');
    const purgecss = require('gulp-purgecss');

    return gulp.src('./Styles/site.css')
        .pipe(postcss([
            require('precss'),
            require('tailwindcss'),
            require('autoprefixer')
        ]))
        //.pipe(purgecss({ content: ['**/*.html', '**/*.razor', '**/*.cshtml', 'Views/**/*.cshtml', 'Views/Shared/_*.cshtml' ] }))
        .pipe(gulp.dest('./wwwroot/css/'));
});