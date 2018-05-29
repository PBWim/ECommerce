/// <binding Clean='dev-js' />
// --------------------------------------------------------------------------------------------------------------------
//  <copyright file= "gulpfile.js" project="ECommerce">
//  Copyright Pabodha Wimalasuriya.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

"use strict";

// Required gulp commands
var gulp = require("gulp"),
    rimraf = require("rimraf"), // A Node deletion module
    concat = require("gulp-concat"), // A module that concatenates files based on 
                                     // the operating system's newline character
    cssmin = require("gulp-cssmin"), // A module that minifies CSS files
    uglify = require("gulp-uglify"); // A module that minifies .js files

// For bootstrap, popper and JQuery
const vendorStyles = [
    "node_modules/bootstrap/dist/css/bootstrap.min.css"
];
const vendorScripts = [
    "node_modules/jquery/dist/jquery.min.js",
    "node_modules/popper.js/dist/umd/popper.min.js",
    "node_modules/bootstrap/dist/js/bootstrap.min.js",
];

// For site.css and site.js
var paths = {
    webroot: "./wwwroot/"
};

//paths.js = paths.webroot + "js/**/*.js";
//paths.minJs = paths.webroot + "js/**/*.min.js";
paths.css = paths.webroot + "css/**/*.css";
paths.minCss = paths.webroot + "css/**/*.min.css";
//paths.concatJsDest = paths.webroot + "js/site.min.js";
paths.concatCssDest = paths.webroot + "css/site.min.css";

// This is the default(First) task runs
gulp.task('default', ['build-vendor']);

gulp.task('build-vendor', ['build-vendor-css', 'build-vendor-js', 'clean', 'min', 'dev']);

gulp.task('build-vendor-css', () => {
    return gulp.src(vendorStyles)
        .pipe(concat('vendor.min.css'))
        .pipe(gulp.dest('wwwroot'));
});

gulp.task('build-vendor-js', () => {
    return gulp.src(vendorScripts)
        .pipe(concat('vendor.min.js'))
        .pipe(gulp.dest('wwwroot'));
});

// --------------------------------------------------------- //

// Defining Tasks
//gulp.task("clean:js", function (cb) {
//    rimraf(paths.concatJsDest, cb);
//    // A task that uses the rimraf Node deletion module to 
//    // remove the minified version of the site.js file.
//});

// Defining Tasks
gulp.task("clean:css", function (cb) {
    rimraf(paths.concatCssDest, cb);
    // A task that uses the rimraf Node deletion module 
    // to remove the minified version of the site.css file.
});

// Executing defined tasks in order
// A task that calls the clean:js task, followed by the clean:css task.
//gulp.task("clean", ["clean:js", "clean:css"]);
gulp.task("clean", ["clean:css"]);

//gulp.task("min:js", function () {
//    return gulp.src([paths.js, "!" + paths.minJs], { base: "." })
//        .pipe(concat(paths.concatJsDest))
//        .pipe(uglify())
//        .pipe(gulp.dest("."));
//    // A task that minifies and concatenates all .js 
//    // files within the js folder.The.min.js files are excluded.
//});

gulp.task("min:css", function () {
    return gulp.src([paths.css, "!" + paths.minCss])
        .pipe(concat(paths.concatCssDest))
        .pipe(cssmin())
        .pipe(gulp.dest("."));

    // A task that minifies and concatenates all .css 
    // files within the css folder.The.min.css files are excluded.
});

//gulp.task("min", ["min:js", "min:css"]);
gulp.task("min", ["min:css"]);

// --------------------------------------------------------- //

var tsProject;
gulp.task("dev", function () {
    var ts = require("gulp-typescript");
    //var sourcemaps = require('gulp-sourcemaps');

    if (!tsProject) {
        tsProject = ts.createProject("tsconfig.json");
    }

    var reporter = ts.reporter.fullReporter();
    var tsResult = tsProject.src()
        //.pipe(sourcemaps.init())
        .pipe(tsProject(reporter));

    return tsResult.js
        .pipe(gulp.dest("wwwroot/js/scripts"));
});