;(function(window) {

  var svgSprite = '<svg>' +
    '' +
    '<symbol id="icon-fanhui" viewBox="0 0 1024 1024">' +
    '' +
    '<path d="M738.145103 170.248828 663.234207 95.337931 313.114483 445.457655 312.937931 445.298759 238.768552 519.450483 238.945103 519.627034 238.768552 519.785931 313.679448 594.696828 313.838345 594.537931 658.996966 939.696552 733.166345 865.509517 388.007724 520.368552Z"  ></path>' +
    '' +
    '</symbol>' +
    '' +
    '<symbol id="icon-iconaddress" viewBox="0 0 1024 1024">' +
    '' +
    '<path d="M510.605234 62.584384c-179.710988 0-325.394998 145.68401-325.394998 325.394998s325.394998 571.143005 325.394998 571.143005S836.000232 567.69037 836.000232 387.979382 690.315198 62.584384 510.605234 62.584384zM510.605234 536.863271c-91.974761 0-166.534897-74.560136-166.534897-166.534897s74.560136-166.534897 166.534897-166.534897 166.534897 74.560136 166.534897 166.534897S602.578971 536.863271 510.605234 536.863271z"  ></path>' +
    '' +
    '</symbol>' +
    '' +
    '<symbol id="icon-gouwuche" viewBox="0 0 1024 1024">' +
    '' +
    '<path d="M825.216 753.92c-45.504 0-82.304 36.928-82.304 82.368 0 45.504 36.8 82.304 82.304 82.304 45.568 0 82.432-36.8 82.432-82.304C907.648 790.848 870.72 753.92 825.216 753.92zM413.376 753.92c-45.504 0-82.368 36.928-82.368 82.368 0 45.504 36.864 82.304 82.368 82.304 45.44 0 82.368-36.8 82.368-82.304C495.744 790.848 458.816 753.92 413.376 753.92zM269.504 215.232 159.744 105.344c0 0-80.576 0-126.784 0-46.144 0-41.6 82.432 0 82.432 41.472 0 99.392 0 99.392 0l82.368 82.304 143.808 428.864 549.184 0L1024 215.232 269.504 215.232z"  ></path>' +
    '' +
    '</symbol>' +
    '' +
    '<symbol id="icon-459ruanjianpan" viewBox="0 0 1024 1024">' +
    '' +
    '<path d="M896.302643 270.565229l-682.971953-1.346671-51.001581-0.441045-33.828456 1.787716c-35.338856 0-63.971987 28.628014-63.971987 63.995523l0 351.877139c0 35.332716 28.633131 63.995523 63.971987 63.995523L896.307759 750.433414c35.33374 0 63.995523-28.662807 63.995523-63.995523L960.303282 334.560752C960.303282 299.193243 931.641499 270.565229 896.302643 270.565229zM194.433294 566.744835l0-105.400538 113.586988 0 0 105.400538L194.433294 566.744835zM333.602937 461.344297l127.913275 0 0 105.400538-127.913275 0L333.602937 461.344297zM487.098867 461.344297l128.936581 0 0 105.400538-128.936581 0L487.098867 461.344297zM641.618103 461.344297l120.750131 0 0 105.400538-120.750131 0L641.618103 461.344297zM787.950889 461.344297l88.004333 0 0 105.400538-88.004333 0L787.950889 461.344297zM901.537877 461.344297l26.78197 0 0 105.400538-26.78197 0L901.537877 461.344297zM128.499629 302.548664 896.307759 302.548664c17.666358 0 32.012088 14.316054 32.012088 32.012088l0 101.20089L755.205091 435.761642 755.205091 302.653041l-25.582655 0 0 133.1086-138.146337 0L591.476099 302.653041l-25.582655 0 0 133.1086-138.146337 0L427.747107 302.653041l-25.582655 0 0 133.1086-137.123031 0L265.041422 302.653041l-25.582655 0 0 133.1086L96.511077 435.761642l0-101.20089C96.511077 316.864718 110.828155 302.548664 128.499629 302.548664zM96.511077 686.437891 96.511077 461.344297l72.339562 0 0 105.400538-72.240301 0 0 25.582655 144.895041 0 0 126.122489L128.499629 718.449979C110.828155 718.449979 96.511077 704.105273 96.511077 686.437891zM896.307759 718.449979 267.088034 718.449979l0-126.122489 661.231813 0 0 94.110401C928.319847 704.105273 913.974118 718.449979 896.307759 718.449979z"  ></path>' +
    '' +
    '</symbol>' +
    '' +
    '<symbol id="icon-fankui" viewBox="0 0 1114 1024">' +
    '' +
    '<path d="M715.861333 393.443556c-13.340444-13.340444-34.958222-13.340444-48.298667 0l-84.48 84.48-84.48-84.48c-13.340444-13.340444-34.929778-13.340444-48.270222 0-13.340444 13.340444-13.340444 34.929778 0 48.270222l84.48 84.48-84.48 84.48c-13.340444 13.340444-13.340444 34.958222 0 48.270222 13.340444 13.340444 34.929778 13.340444 48.270222 0l84.48-84.48 84.48 84.48c13.340444 13.340444 34.958222 13.340444 48.298667 0.028444 13.312-13.340444 13.312-34.958222 0-48.298667l-84.48-84.48 84.48-84.48C729.173333 428.373333 729.173333 406.784 715.861333 393.443556L715.861333 393.443556zM583.082667 99.527111c-235.633778 0-426.666667 191.032889-426.666667 426.666667 0 235.633778 191.032889 426.666667 426.666667 426.666667 235.662222 0 426.666667-191.032889 426.666667-426.666667C1009.749333 290.56 818.716444 99.527111 583.082667 99.527111L583.082667 99.527111zM583.082667 884.593778c-197.916444 0-358.4-160.455111-358.4-358.4 0-197.916444 160.483556-358.4 358.4-358.4 197.944889 0 358.4 160.483556 358.4 358.4C941.482667 724.138667 781.027556 884.593778 583.082667 884.593778L583.082667 884.593778zM583.082667 884.593778"  ></path>' +
    '' +
    '</symbol>' +
    '' +
    '<symbol id="icon-caidan" viewBox="0 0 1024 1024">' +
    '' +
    '<path d="M1.114 511.774c0-56.444 45.767-102.177 102.177-102.177 56.444 0 102.175 45.733 102.175 102.176 0 56.444-45.731 102.178-102.175 102.178C46.881 613.951 1.114 568.218 1.114 511.774zM409.822 511.774c0-56.444 45.767-102.177 102.178-102.176 56.443 0 102.177 45.733 102.177 102.175 0 56.444-45.733 102.178-102.177 102.178C455.589 613.951 409.822 568.218 409.822 511.774zM818.532 511.774c0-56.444 45.767-102.176 102.177-102.176 56.443 0 102.177 45.733 102.177 102.175 0 56.444-45.733 102.178-102.177 102.178C864.299 613.951 818.532 568.218 818.532 511.774z"  ></path>' +
    '' +
    '</symbol>' +
    '' +
    '<symbol id="icon-caidan01" viewBox="0 0 1024 1024">' +
    '' +
    '<path d="M63.97301 790.894941l0-67.157539 895.456369 0 0 67.157539L63.97301 790.894941zM63.97301 477.484905l895.456369 0 0 67.157539L63.97301 544.642444 63.97301 477.484905zM63.97301 231.234455l895.456369 0 0 67.159586L63.97301 298.394041 63.97301 231.234455z"  ></path>' +
    '' +
    '</symbol>' +
    '' +
    '<symbol id="icon-dingwei" viewBox="0 0 1204 1024">' +
    '' +
    '<path d="M605.486974 0.077787c-175.182226-4.004165-330.343626 147.15307-326.33946 320.333213 0 64.066643 45.046858 169.175978 112.116624 276.287396 68.070808 107.111418 118.122872 178.18535 174.181184 253.263446 10.010413 13.013537 23.02395 20.020826 40.041652 20.020826 16.016661 0 31.03228-8.00833 40.041652-20.020826 56.058312-75.078097 107.111418-146.152028 174.181184-253.263446 67.069766-107.111418 112.116624-212.220753 112.116624-276.287396C935.687594 147.230856 782.528277-3.926379 605.486974 0.077787L605.486974 0.077787 605.486974 0.077787 605.486974 0.077787zM628.510924 774.883745c-5.005206 7.007289-14.014578 11.011454-23.02395 11.011454-8.00833 0-18.018743-3.003124-22.022908-11.011454C433.307873 570.671322 339.209991 396.490137 339.209991 320.410999c0-72.074973 26.027074-134.139533 78.081221-185.192639 52.054147-51.053106 115.119748-77.080179 188.195762-77.080179 73.076014 0 136.141615 26.027074 188.195762 77.080179 53.055188 51.053106 79.082262 113.117666 79.082262 185.192639 0 39.04061-22.022908 98.102046-66.068725 179.186391C763.651498 580.681735 703.589021 671.776492 628.510924 774.883745L628.510924 774.883745 628.510924 774.883745 628.510924 774.883745zM603.484892 1024.00002c-114.118707 0-220.229084-10.010413-295.30718-30.031239-40.041652-10.010413-71.073932-22.022908-93.09684-37.038528-27.028115-17.017702-42.043734-39.04061-42.043734-63.065601 0-31.03228 12.012495-54.05623 37.038528-71.073932 28.029156-18.018743 73.076014-28.029156 135.140574-29.030197l1.001041 43.044775c-53.055188 0-91.094757 9.009372-112.116624 22.022908-12.012495 8.00833-18.018743 20.020826-18.018743 35.036445 0 17.017702 32.033321 40.041652 103.107253 59.061436C394.267262 971.945873 488.365143 982.099292 603.484892 982.099292c110.114542 0 212.220753-11.011454 283.294685-29.030197 69.071849-17.017702 101.10517-40.041652 101.10517-59.061436 0-8.00833-4.004165-16.016661-13.013537-25.026032-10.010413-10.010413-42.043734-36.037486-111.115583-36.037486l-3.003124 0-1.001041-43.044775c31.03228 0 60.062477 4.004165 85.08851 13.013537 25.026032 9.009372 45.046858 21.021867 60.062477 36.037486 17.017702 17.017702 26.027074 35.036445 26.027074 55.057271 0 24.024991-14.014578 46.047899-41.042693 63.065601-22.022908 15.015619-53.055188 27.028115-93.09684 37.038528C822.569928 1013.989607 718.60464 1024.00002 603.484892 1024.00002L603.484892 1024.00002 603.484892 1024.00002 603.484892 1024.00002zM367.239147 813.924355c1.001041 12.012495-8.00833 22.022908-20.020826 23.02395l-32.033321 2.002083c-12.012495 0-22.022908-9.009372-22.022908-20.020826-1.001041-12.012495 8.00833-22.022908 20.020826-23.02395l32.033321-2.002083C356.227693 793.903529 367.239147 802.912901 367.239147 813.924355L367.239147 813.924355 367.239147 813.924355zM911.662603 813.924355c-1.001041 12.012495-11.011454 21.021867-22.022908 20.020826l-32.033321-1.001041c-12.012495 0-21.021867-10.010413-21.021867-22.022908 1.001041-12.012495 10.010413-21.021867 22.022908-20.020826l32.033321 1.001041C902.653231 791.901447 911.662603 801.91186 911.662603 813.924355L911.662603 813.924355 911.662603 813.924355zM517.824359 332.852512c0-46.476917 37.610551-84.087468 84.087468-84.087468 46.476917 0 84.087468 37.610551 84.087468 84.087468s-37.610551 84.087468-84.087468 84.087468C555.43491 416.939981 517.824359 379.329429 517.824359 332.852512L517.824359 332.852512zM517.824359 332.852512"  ></path>' +
    '' +
    '</symbol>' +
    '' +
    '<symbol id="icon-iconfontdianhua5" viewBox="0 0 1024 1024">' +
    '' +
    '<path d="M927.960825 170.09498l-81.808496-81.583087c-22.59655-22.526039-59.210923-22.526039-81.807473 0l-122.727071 163.166173c-18.738528 27.620058-22.59655 59.042721 0 81.583087l50.079587 49.92404c-37.115813 49.743938-81.697974 103.998609-131.860453 154.033166-56.727257 56.559157-119.866813 108.023272-176.608396 150.216233l-48.384923-48.244794c-22.582223-22.539342-54.104415-18.709107-81.808496 0L89.417089 761.551636c-27.426753 18.931165-22.59655 59.07035 0 81.610716l81.808496 81.554434c45.178773 45.080731 103.947609 30.645974 163.616992 0 0 0 180.592291-101.097536 335.200749-255.268848 145.434142-145.027048 257.917499-336.186785 257.917499-336.186785C951.418011 268.944312 973.153925 215.148082 927.960825 170.09498zM890.140948 292.470121c-48.302032 91.784426-155.622596 233.118362-245.454142 326.34565C541.129093 730.794122 297.008374 883.940081 297.008374 883.940081c-18.849049 9.882068-71.148279 10.632151-85.528366-3.691065l-52.063859-51.936883c-10.743109-17.960047-15.573312-38.779212 0-51.909254l104.126695-77.864392c17.628195-11.908214 37.683771-14.350846 52.063859 0l64.139367 63.956637c15.115875-10.603499 256.113336-168.551834 390.1658-385.957329l-65.70816-65.524342c-14.380088-14.337543-11.936333-34.338063 0-51.922557l78.089649-103.83181c14.379065-19.166525 37.670468-14.337543 52.049532 0l52.077163 51.922557C906.824593 226.334865 900.910664 270.984784 890.140948 292.470121z"  ></path>' +
    '' +
    '</symbol>' +
    '' +
    '<symbol id="icon-chazhao" viewBox="0 0 1024 1024">' +
    '' +
    '<path d="M948.032 902.784l-206.976-206.976C797.696 628.928 832 542.528 832 448c0-212.064-171.936-384-384-384S64 235.936 64 448s171.936 384 384 384c94.528 0 180.928-34.304 247.808-90.912l206.976 206.976c14.016 14.016 35.488 15.232 48 2.72C963.264 938.272 962.048 916.8 948.032 902.784zM448 768C271.264 768 128 624.736 128 448S271.264 128 448 128s320 143.264 320 320S624.736 768 448 768z"  ></path>' +
    '' +
    '</symbol>' +
    '' +
    '<symbol id="icon-fanhuidingbu" viewBox="0 0 1024 1024">' +
    '' +
    '<path d="M507.489002 16.552986c-276.445602 0-500.547019 224.102431-500.547019 500.548032 0 276.444589 224.107495 500.552084 500.547019 500.552084 276.443576 0 500.553097-224.107495 500.553097-500.552084C1008.042099 240.655417 783.932578 16.552986 507.489002 16.552986L507.489002 16.552986zM711.94907 533.852534c-12.211651 12.217728-32.024183 12.217728-44.236847 0L538.779838 404.919137l0 331.170125c0 17.282282-14.008554 31.290836-31.290836 31.290836-17.27114 0-31.28172-14.008554-31.28172-31.290836L476.207283 404.919137 347.27186 533.852534c-12.217728 12.217728-32.025196 12.217728-44.236847 0-12.223806-12.217728-12.223806-32.025196 0-44.243937l176.967646-176.967646c7.503642-7.503642 17.781647-9.831311 27.486344-8.121518 9.709762-1.709793 19.987766 0.617875 27.491408 8.121518l176.968659 176.967646C724.165785 501.827338 724.165785 521.634806 711.94907 533.852534L711.94907 533.852534zM711.94907 533.852534"  ></path>' +
    '' +
    '</symbol>' +
    '' +
    '<symbol id="icon-fanhuidingbu2" viewBox="0 0 1024 1024">' +
    '' +
    '<path d="M542.520963 383.617108l0.083943-0.086941-29.758824-29.347103-0.135908 0.135908-0.075949-0.070952-29.634308 29.350101 0.084942 0.083943L6.116645 855.982644l29.710856 29.288143L512.833291 412.930233l478.072667 471.285269 29.643702-29.352099L542.520963 383.617108zM35.014852 532.099237 512.028237 59.765479l478.070068 471.292264 29.642702-29.355897L541.686529 30.425571l0.089939-0.084942L512.107183 1.096457l-0.066955 0.070952-0.1479-0.143902-29.70486 29.408061 0.084942 0.08794L5.307194 502.813093 35.014852 532.099237z"  ></path>' +
    '' +
    '</symbol>' +
    '' +
    '<symbol id="icon-fujin" viewBox="0 0 1024 1024">' +
    '' +
    '<path d="M584.891023 722.775389c67.247667-103.428563 160.043316-249.39029 185.387459-305.567164 45.059274-99.936099 36.981158-128.913129 36.981158-156.445157C807.25964 116.738579 664.610695 0 511.431512 0 358.253839 0 215.577716 116.759718 215.577716 260.763068c0 27.532028-8.103784 56.510568 36.981158 156.445157 25.319984 56.154225 118.18962 202.205038 185.464465 305.588303C239.482897 733.968486 88.551997 789.034053 88.551997 855.448239c0 74.495321 189.579019 168.551761 423.435169 168.551761 233.881819 0 423.460838-94.080598 423.460838-168.551761C935.470652 788.943457 783.985608 733.746527 584.891023 722.775389L584.891023 722.775389zM384.987115 265.191687c0-62.809988 56.872951-113.754961 127.024209-113.754961 70.151258 0 127.051388 50.946483 127.051388 113.754961 0 62.831127-56.900129 113.754961-127.051388 113.754961C441.834397 378.969297 384.987115 328.046973 384.987115 265.191687L384.987115 265.191687zM512.012834 922.929945c-175.393245 0-317.589211-45.312941-317.589211-101.17877 0-47.765065 104.154838-87.692093 244.028535-98.288768 41.34938 63.566462 72.979354 110.931396 72.979354 110.931396s31.629973-47.408722 73.029181-111.018971c140.405192 10.415484 245.115683 50.479915 245.115683 98.376344C829.576377 877.617003 687.427218 922.929945 512.012834 922.929945L512.012834 922.929945z"  ></path>' +
    '' +
    '</symbol>' +
    '' +
    '<symbol id="icon-biaoqingshanchujian" viewBox="0 0 1024 1024">' +
    '' +
    '<path d="M918.71232 848.32256l-566.8864-0.90112c-14.37696 1.1264-28.30336-3.91168-38.25664-13.824L20.21376 538.80832c-9.23648-9.29792-14.29504-21.62688-14.25408-34.7136 0.02048-13.1072 5.16096-25.3952 14.45888-34.6112L308.85888 182.41536c11.42784-11.40736 23.51104-11.89888 33.23904-12.288 2.12992-0.08192 4.48512-0.18432 7.10656-0.4096l569.4464-2.43712c46.81728 0 84.8896 38.01088 84.91008 84.74624l0 511.50848C1003.54048 810.27072 965.50912 848.32256 918.71232 848.32256zM351.10912 806.46144l204.86144 0.90112 362.76224 0c24.18688 0 43.86816-19.6608 43.86816-43.84768L962.60096 252.02688c-0.02048-24.14592-19.68128-43.78624-43.86816-43.78624l-567.62368 2.3552c-1.61792 0.22528-4.608 0.34816-7.35232 0.45056-2.31424 0.08192-5.48864 0.22528-6.41024 0.47104L49.29536 498.52416c-2.06848 2.048-2.37568 4.44416-2.37568 5.69344 0 1.24928 0.28672 3.64544 2.3552 5.71392L342.56896 804.6592c0.45056 0.43008 1.96608 1.96608 5.34528 1.96608L351.10912 806.46144z"  ></path>' +
    '' +
    '<path d="M710.79936 627.75296 684.29824 654.27456 571.392 541.40928 458.50624 654.27456 431.94368 627.75296 544.84992 514.82624 431.94368 401.92 458.50624 375.35744 571.392 488.26368 684.29824 375.35744 710.79936 401.92 597.9136 514.82624Z"  ></path>' +
    '' +
    '</symbol>' +
    '' +
    '<symbol id="icon-iconfwcgzn" viewBox="0 0 1024 1024">' +
    '' +
    '<path d="M512 950.857143C269.628952 950.857143 73.142857 754.371048 73.142857 512 73.142857 269.628952 269.628952 73.142857 512 73.142857 754.371048 73.142857 950.857143 269.628952 950.857143 512 950.857143 754.371048 754.371048 950.857143 512 950.857143ZM512 121.904762C296.545524 121.904762 121.904762 296.545524 121.904762 512 121.904762 727.454476 296.545524 902.095238 512 902.095238 727.454476 902.095238 902.095238 727.454476 902.095238 512 902.095238 296.545524 727.454476 121.904762 512 121.904762ZM580.973714 580.949333 580.949333 580.949333 580.949333 580.949333C567.466667 594.456381 550.009905 603.89181 530.529524 607.646476L287.890286 736.109714 416.329143 493.494857C419.986286 474.453333 429.372952 457.606095 442.392381 444.269714L443.050667 443.050667 443.318857 443.318857C456.825905 429.860571 473.990095 420.10819 493.470476 416.353524L736.109714 287.890286 607.646476 530.529524C603.89181 550.009905 594.456381 567.466667 580.973714 580.949333ZM512 463.238095C485.059048 463.238095 463.238095 485.059048 463.238095 512 463.238095 538.940952 485.059048 560.761905 512 560.761905 538.940952 560.761905 560.761905 538.940952 560.761905 512 560.761905 485.059048 538.940952 463.238095 512 463.238095Z"  ></path>' +
    '' +
    '</symbol>' +
    '' +
    '<symbol id="icon-shouzhiicon" viewBox="0 0 1024 1024">' +
    '' +
    '<path d="M800.275 838.765c-21.931 43.942-35.797 94.145-85.435 119.863-0.256 0.131-80.417 3.966-133.86 3.966-35.37 0-117.498-1.287-118.193-1.459-34.082-8.128-104.879-69.216-161.975-126.703l-13.308-13.383c-81.805-81.919-139.13-145.94-139.711-146.587-34.486-34.51-34.404-91.818 0.803-127.073 17.029-17.077 39.558-26.474 63.438-26.474 23.872 0 46.409 9.396 63.438 26.474l63.3 66.536-0.788-346.813 0.508 0.33V122.624s14.17-57.899 69.282-57.928c54.619-0.032 70.647 27.568 75.054 57.928v150.614l0.868-0.262v74.907c15.913-11.404 35.695-17.3 54.947-17.3 33.084 0 61.373 21.042 72.2 50.454 13.276-10.89 30.224-17.432 48.686-17.432 40.461 0 73.724 31.437 76.716 71.212 11.661-3.63 23.018-5.18 27.495-5.18 37.95 0 71.24 30.868 71.247 66.041 0 11.167-0.391 274.362-34.712 343.087zM763.741 462.66c-7.762 0-20.693 4.27-27.29 7.496v42.032c0 9.117-7.387 16.52-16.473 16.52-9.097 0-16.487-7.402-16.487-16.52v-71.536c0-24.277-19.72-44.028-43.961-44.028-24.248 0-43.967 19.751-43.967 44.028v27.508c0 9.12-7.375 16.517-16.48 16.517-9.096 0-16.471-7.397-16.471-16.517v-60.531c0-24.273-19.72-44.024-43.968-44.024-22.095 0-54.947 13.192-54.947 49.528v44.024c0 9.118-7.38 16.513-16.48 16.513-9.1 0-16.483-7.395-16.483-16.513V148.975c0-11.628-2.787-49.354-38.697-49.354-30.517 0-41.345 26.855-41.345 49.698l1.148 505.926c0.007 6.752-4.08 12.835-10.342 15.349a16.493 16.493 0 0 1-18.086-3.925l-91.54-96.229c-10.523-10.538-24.766-16.505-39.837-16.505-15.072 0-29.33 5.967-40.123 16.8-10.842 10.852-16.808 25.24-16.849 40.55-0.04 15.31 5.891 29.683 16.67 40.486 1.188 1.292 57.971 64.692 139.088 145.923l13.358 13.438c50.925 51.284 75.45 93.441 139.886 115.634 26.778 9.23 81.57 6.86 116.916 6.86 47.342 0 111.461 1.459 118.338-4.09C735.607 900.28 750.424 864.78 770.772 824c25.61-51.302 31.248-254.395 31.248-328.32 0-16.968-18.613-33.019-38.279-33.019z" fill="" ></path>' +
    '' +
    '</symbol>' +
    '' +
    '<symbol id="icon-next" viewBox="0 0 1024 1024">' +
    '' +
    '<path d="M517.101 71.694c243.675 0 441.223 197.542 441.223 441.223s-197.542 441.223-441.223 441.223c-243.675 0-441.223-197.542-441.223-441.223 0-243.675 197.542-441.223 441.223-441.223v0zM405.458 676.72l46.797 46.797 210.593-210.593-210.593-210.593-46.797 46.797 164.288 164.288-164.288 163.306z"  ></path>' +
    '' +
    '</symbol>' +
    '' +
    '<symbol id="icon-prev" viewBox="0 0 1024 1024">' +
    '' +
    '<path d="M514.479 74.717c-242.781 0-439.599 196.81-439.599 439.599s196.81 439.599 439.599 439.599c242.781 0 439.599-196.81 439.599-439.599 0-242.781-196.81-439.599-439.599-439.599v0zM625.72 677.503l-46.623 46.623-209.824-209.819 209.824-209.824 46.623 46.638-163.687 163.674 163.687 162.703z"  ></path>' +
    '' +
    '</symbol>' +
    '' +
    '<symbol id="icon-sousuo-sousuo" viewBox="0 0 1024 1024">' +
    '' +
    '<path d="M703.873 232.437c-130.172-130.232-341.269-130.232-471.502 0s-130.233 341.33 0 471.502c60.328 60.346 143.68 97.672 235.751 97.672 92.070 0 175.422-37.327 235.75-97.672 60.347-60.329 97.673-143.681 97.673-235.751 0-92.070-37.327-175.422-97.672-235.75zM159.787 776.525c-78.944-78.924-127.773-187.968-127.773-308.416 0-240.856 195.253-436.109 436.109-436.109 240.856 0 436.109 195.253 436.109 436.109 0 120.448-48.83 229.492-127.773 308.415-78.917 78.897-187.928 127.694-308.336 127.694-120.409 0-229.419-48.797-308.336-127.694zM974.418 974.484c-10.772 10.789-25.662 17.463-42.112 17.463s-31.34-6.674-42.111-17.462l-84.163-84.223c-10.77-10.77-17.431-25.648-17.431-42.082 0-32.868 26.645-59.512 59.512-59.512 16.433 0 31.312 6.661 42.082 17.43l84.222 84.163c10.818 10.759 17.512 25.653 17.512 42.111s-6.695 31.353-17.51 42.109z"  ></path>' +
    '' +
    '</symbol>' +
    '' +
    '</svg>'
  var script = function() {
    var scripts = document.getElementsByTagName('script')
    return scripts[scripts.length - 1]
  }()
  var shouldInjectCss = script.getAttribute("data-injectcss")

  /**
   * document ready
   */
  var ready = function(fn) {
    if (document.addEventListener) {
      if (~["complete", "loaded", "interactive"].indexOf(document.readyState)) {
        setTimeout(fn, 0)
      } else {
        var loadFn = function() {
          document.removeEventListener("DOMContentLoaded", loadFn, false)
          fn()
        }
        document.addEventListener("DOMContentLoaded", loadFn, false)
      }
    } else if (document.attachEvent) {
      IEContentLoaded(window, fn)
    }

    function IEContentLoaded(w, fn) {
      var d = w.document,
        done = false,
        // only fire once
        init = function() {
          if (!done) {
            done = true
            fn()
          }
        }
        // polling for no errors
      var polling = function() {
        try {
          // throws errors until after ondocumentready
          d.documentElement.doScroll('left')
        } catch (e) {
          setTimeout(polling, 50)
          return
        }
        // no errors, fire

        init()
      };

      polling()
        // trying to always fire before onload
      d.onreadystatechange = function() {
        if (d.readyState == 'complete') {
          d.onreadystatechange = null
          init()
        }
      }
    }
  }

  /**
   * Insert el before target
   *
   * @param {Element} el
   * @param {Element} target
   */

  var before = function(el, target) {
    target.parentNode.insertBefore(el, target)
  }

  /**
   * Prepend el to target
   *
   * @param {Element} el
   * @param {Element} target
   */

  var prepend = function(el, target) {
    if (target.firstChild) {
      before(el, target.firstChild)
    } else {
      target.appendChild(el)
    }
  }

  function appendSvg() {
    var div, svg

    div = document.createElement('div')
    div.innerHTML = svgSprite
    svgSprite = null
    svg = div.getElementsByTagName('svg')[0]
    if (svg) {
      svg.setAttribute('aria-hidden', 'true')
      svg.style.position = 'absolute'
      svg.style.width = 0
      svg.style.height = 0
      svg.style.overflow = 'hidden'
      prepend(svg, document.body)
    }
  }

  if (shouldInjectCss && !window.__iconfont__svg__cssinject__) {
    window.__iconfont__svg__cssinject__ = true
    try {
      document.write("<style>.svgfont {display: inline-block;width: 1em;height: 1em;fill: currentColor;vertical-align: -0.1em;font-size:16px;}</style>");
    } catch (e) {
      console && console.log(e)
    }
  }

  ready(appendSvg)


})(window)