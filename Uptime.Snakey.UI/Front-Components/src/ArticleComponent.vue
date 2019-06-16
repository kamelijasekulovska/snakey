<template>


    <div class="feed-container">
        <div class="overlay" v-if="showArticle" @click="show"></div>

        <div class="article" v-for="item in articles" @click="createArticle(item.Link);">
            <div class="article-cover">
                <div class="img-zoom">
                    <img class="article-img" v-bind:src="item.ImageUrl" />
                </div>
                <div class="article-date">
                    <div class="date">
                        <p>{{ item.PublishedDate }}</p>
                    </div>
                </div>
            </div>
            <div class="article-info">
                <h3>{{ item.Title }}</h3>
                <p class="desc">{{item.Description}}</p>
                <p class="author">{{item.Author}}</p>
            </div>

        </div>
        <div class="modal" v-if="showArticle">
            <button class="close" @click="show"><p>x</p></button>
            <div class="modal-inner">
                <h2>{{clutterFreeArticle.Title}}</h2>
                <small>{{clutterFreeArticle.Author}}</small>
                <small>{{clutterFreeArticle.Date_published}}</small>
                <small>{{clutterFreeArticle.Category}}</small>
                <div v-html="clutterFreeArticle.Content" class="modal-content"></div>
            </div>
        </div>
    </div>


</template>

<script>
    import axios from "axios";
    export default {
        data() {
            return {
                articles: [],
                showArticle: false,
                clutterFreeArticle: [],


            }
        },

        created() {
            axios.get('http://localhost:63463/Snakey/GetRssFeed').then((response) => {
                this.articles = response.data;
                for (var i = 0; i < this.articles.length; i++) {

                    var mediaUrl = this.articles[i].ImageUrl;
                    if (mediaUrl == "") {
                        this.articles[i].ImageUrl = "https://www.wav1.com/wp-content/uploads/2014/01/blackimg.png"
                    }
                    else {
                        var url = mediaUrl.substring(1, mediaUrl.length - 1).split(" ")[1];
                        var cleanUrl = url.substring(5, url.length - 1);
                        this.articles[i].ImageUrl = cleanUrl;
                    }

                }
            })
                .catch((e) => {
                    console.error(e)
                })

        },
        methods: {
            createArticle(currentUrl) {
                window.scrollTo(0, 0);
                this.showArticle = !this.showArticle;

                axios.post('http://localhost:63463/Snakey/GetCleanArticleFrom', {
                    url: currentUrl,
                }).then((response) => {
                    this.clutterFreeArticle = response.data;
                })

                    .catch((e) => {
                        console.error(e)
                    })

            },
            show() {
                this.showArticle = !this.showArticle
            }


        }
    }


</script>

<style scoped lang="scss">
    .feed-container {
    padding: 5% 2%;
    display: flex;
    flex-wrap: wrap;
    justify-content: space-evenly;
    .article {
        width: 350px;
        margin: 10px;
        box-shadow: 1px 1px 8px -4px rgba(0,0,0,0.54);
        padding: 15px;
        .article-info {
            h3 {
                font-size: 22px;
                font-weight: 600;
                text-transform: uppercase;
                margin: 5px 0 10px 0;
                transition: color 0.3s ease;
                cursor: pointer;
                color: #000;
            }
            h3:hover {
                color: #dd0516;
            }
            .desc {
                font-size: 14px;
                cursor: pointer;
            }
            .author {
                font-size: 12px;
            }
        }
        .article-cover {
            position: relative;
            transition: .5s ease;
            cursor: pointer;
            .img-zoom {
                height: 300px;
                overflow: hidden;
            }
            .img-zoom:hover .article-img {
                transform: scale(1.5);
            }
            .article-img {
                width: 350px;
                height: 300px;
                object-fit: cover;
                transition: transform .5s ease;
            }
            .article-date {
                display: flex;
                flex-direction: column;
                position: absolute;
                top: 10px;
                z-index: 5;
                left: 10px;
                width: 90px;
                color: #ffffff;
                height: 90px;
                background-color: #0f0f0f63;
                .date {
                    text-transform: uppercase;
                    font-size: 14px;
                    text-align: left;
                    padding: 0px 5px;
                }
            }
        }
    }
}
@media screen and (max-width:768px) {
    .feed-container {
        flex-direction: column;
        align-content: center;
    }
    .modal {
        top: 5em;
    }
}
button {
    background-color: #dd0516;
    padding: 10px 20px;
    border: 0;
    border-radius: 10px;
    p {
        font-size: 14px;
    }
}
.overlay {
    position: fixed;
    z-index: 9998;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background-color: rgba(0,0,0,0.5);
}
.modal {
    padding: 20px 30px;
    position: absolute;
    width: 80%;
    z-index: 9999;
    margin: 0 auto;
    background-color: #fff;
    .modal-inner {
        padding: 5% 2%;
        display: flex;
        flex-direction: column;
        align-items: center;
    }
    .modal-content {
        text-align: center;
        width: 90%;
        overflow: hidden;
    }
}
.close {
    position: absolute;
    top: 10px;
    right: 10px;
}
    
</style>