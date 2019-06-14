<template>
    <div class="container">
        <div class="feed-container">
            <div class="article-box" v-for="item in Articles">
                <div class="article-info">
                    <h3>{{ item.title }}</h3>
                    <p class="desc">{{ item.desc }}</p>
        
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                Articles: [
                    {
                        title: "Title 1",
                        desc: "Description 1"
                    },
                    {
                        title: "Title 2",
                        desc: "Description 2"
                    },
                    {
                        title: "Title 3",
                        desc: "Description 3"
                    },
                    {
                        title: "Title 4",
                        desc: "Description 4"
                    },
                    {
                        title: "Title 5",
                        desc: "Description 5"
                    },
                    {
                        title: "Title 6",
                        desc: "Description 6"
                    }

                ]
            }
        }
    }
</script>

<style scoped>
    .feed-container{
  padding: 5% 0;
  display: flex;
  flex-wrap: wrap;
  justify-content: space-evenly;
  .article-box{
    width: fit-content;
    margin-bottom: 50px;
    .article-info{
       h3{
        font-size: 24px;
        font-weight: 600;
        text-transform: uppercase;
        margin: 20px 0 10px 0;
        transition: color 0.3s ease;
        cursor: pointer;
         color: #000;

      }
       h3:hover{
        color:#f16776;
      }

      .desc{
        font-size:16px;
        color:#999;
      }
      

    }

    .article-cover{
      position: relative;
      width:375px;
      height: 375px;
      transition: .5s ease;
      cursor: pointer;
      img{
        width:375px;
        height: 375px;
        object-fit: cover;
      }
      .article-date{
        display: flex;
        flex-direction: column;
        position: absolute;
        top: 10px;
        z-index: 99999;
        left: 10px;
        width: 65px;
        color: #ffffff;
        height: 65px;
        background-color: #0f0f0f63;
        .date{
          text-transform: uppercase;
          p:nth-child(1){
            font-size: 24px;
            margin: 5px 0 0 0;
            font-weight: 600;
          }
          p:nth-child(2){
            margin:5px 0 0 0;
          }
        }

      }

    }

  }

}

    @media screen and (max-width: 768px) {
        .feed-container {
            flex-direction: column;
            align-content: center;
        }
    }
</style>