/// <binding AfterBuild='sass' ProjectOpened='sass:watch' />
'use strict';

var gulp = require('gulp');
var sass = require('gulp-sass');

sass.compiler = require('node-sass');

gulp.task('sass', function () {
    return gulp.src('wwwroot/css/**/*.scss')
        .pipe(sass().on('error', sass.logError))
        .pipe(gulp.dest('wwwroot/css'));
});

gulp.task('sass:watch', function () {
    gulp.watch('wwwroot/css/**/*.scss', gulp.series('sass'));
});