/// <binding Clean='ts' />
const gulp = require("gulp");

const browserify = require("browserify");
const tsify = require("tsify");
const ts = require('gulp-typescript');
const babelify = require("babelify");

const source = require("vinyl-source-stream");
const buffer = require("vinyl-buffer");

const rename = require("gulp-rename");
const uglify = require("gulp-uglify");
const sourcemaps = require("gulp-sourcemaps");

const path = require("path");

gulp.task('ts', gulp.series(() => {
  return browserify(path.join('.', 'Scripts', 'main.ts'), {
      debug: true
    })
    .on('error', console.error.bind(console))
    .plugin(tsify, {
      target: "es6",
      module: "commonjs",
    })
    .transform('babelify', {
      presets: ["@babel/preset-env"],
      extensions: ['.ts']
    })
    .bundle()
    .pipe(source('site.min.js'))
    .pipe(buffer())
    .pipe(sourcemaps.init({
      loadMaps: true
    }))
    .pipe(uglify())
    .on('error', (err) => {
      console.log(err.message);
      console.log(err.annotated);
    })
    .pipe(sourcemaps.write('.'))
    .pipe(gulp.dest(path.join('.', 'wwwroot', 'js')));
}));

gulp.task("watch", () => {
  gulp.watch(
    [
      "./scripts/**/*.ts",
      "./scripts/*.ts"
    ],
    gulp.series(["ts"])
  );
});

gulp.task("default", gulp.parallel(["ts", "watch"]));