/* eslint-disable */
const path = require("path");
const fs = require("file-system");
const VueLoaderPlugin = require("vue-loader/lib/plugin");

const appBasePath = "./Front-Components/src/";
const jsEntries = {};

fs.readdirSync(appBasePath).forEach(name => {
    var indexFile = `${appBasePath}${name}/index.js`;
    if (fs.existsSync(indexFile)) {
        jsEntries[name] = indexFile;
    }
});

module.exports = {
    entry: jsEntries,
    output: {
        path: path.resolve(__dirname, "../dist/js/components"),
        filename: "[name].js"
    },
    resolve: {
        alias: {
            vue$: "vue/dist/vue.esm.js"
        }
    },
    module: {
        rules: [
            {
                test: /\.vue$/,
                use: {
                    loader: "vue-loader",
                    options: {
                        js: "babel-loader"
                    }
                }
            },
            {
                test: /\.js$/,
                exclude: /node_modules/,
                use: {
                    loader: "babel-loader",
                    options: {
                        presets: ["@babel/preset-env"]
                    }
                }
            },
            {
                test: /\.(css|scss)$/,
                use: ["vue-style-loader", "style-loader", "css-loader", "sass-loader"]
            }
        ]
    },
    plugins: [new VueLoaderPlugin()],
    optimization: {
        splitChunks: {
            cacheGroups: {
                commons: {
                    test: /[\\/]node_modules[\\/]/,
                    name: "vendors",
                    chunks: "all"
                }
            }
        }
    },
    devtool: "source-map"
};
