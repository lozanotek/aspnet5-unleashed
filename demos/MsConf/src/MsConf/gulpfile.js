/// <binding Clean='clean' />
var gulp = require("gulp"),
  rimraf = require("rimraf"),
  concat = require("gulp-concat"),
  cssmin = require("gulp-cssmin"),
  uglify = require("gulp-uglify"),
  less = require("gulp-less"),
  project = require("./project.json");

var paths = {
    webroot: "./" + project.webroot + "/"
};

paths.js = paths.webroot + "js/**/*.js";
paths.minJs = paths.webroot + "js/**/*.min.js";

paths.angular = paths.webroot + "app/**/*.js";
paths.angularminJs = paths.webroot + "app/**/*.min.js";

paths.css = paths.webroot + "css/**/*.css";
paths.less = paths.webroot + "less/site.less";
paths.lessDest = paths.webroot + "less";
paths.minCss = paths.webroot + "css/**/*.min.css";

paths.concatJsDest = paths.webroot + "js/site.min.js";
paths.concatCssDest = paths.webroot + "css/site.min.css";

gulp.task("clean:js", function (cb) {
    rimraf(paths.concatJsDest, cb);
});

gulp.task("clean:css", function (cb) {
    rimraf(paths.concatCssDest, cb);
});

gulp.task("clean", ["clean:js", "clean:css"]);

gulp.task("min:js", function () {
    gulp.src([paths.js, paths.angular, "!" + paths.minJs, "!" + paths.angularminJs], {
        base: "."
    })
      .pipe(concat(paths.concatJsDest))
      .pipe(uglify())
      .pipe(gulp.dest("."));
});

gulp.task("min:css", function () {
    gulp.src([paths.css, "!" + paths.minCss])
      .pipe(concat(paths.concatCssDest))
      .pipe(cssmin())
      .pipe(gulp.dest("."));
});

gulp.task("less", function () {

    gulp.src(paths.less)
      .pipe(less({
          compress: true
      })).pipe(gulp.dest(paths.lessDest));

});

gulp.task("min", ["min:js", "min:css"]);

gulp.task("watch", function () {

    gulp.watch(paths.webroot + "less/*.less", ["less"]);

})