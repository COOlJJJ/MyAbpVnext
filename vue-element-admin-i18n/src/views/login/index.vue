<template>
  <div class="bodymain">
    <img src="../../assets/backgroundimg/bg.png" alt="" class="wave" />
    <el-header style="padding: 0; width: 100%; position: fixed; z-index: 1"
      ><div style="display: flex; justify-content: end">
        <img
          src="../../assets/LOGO/siemens.svg"
          alt=""
          style="
            width: 170px;
            height: 50px;
            margin-left: 5px;
            margin-right: 5px;
            z-index: 1;
          "
        /></div
    ></el-header>

    <div class="container">
      <div class="img">
        <img src="../../assets/backgroundimg/Pic.svg" alt="" />
      </div>
      <div class="login-container">
        <el-form
          ref="loginForm"
          :model="loginForm"
          :rules="loginRules"
          class="login-form"
          autocomplete="on"
          label-position="left"
        >
          <div class="title-container">
            <h3 class="title">
              {{ $t('MyAbpVnext["Login:Title"]') }}
            </h3>
            <lang-select class="set-language" />
          </div>
          <h5>{{ $t('MyAbpVnext["Login:UserName"]') }}</h5>
          <el-form-item prop="username">
            <span class="svg-container">
              <svg-icon icon-class="user" />
            </span>
            <el-input
              ref="username"
              v-model="loginForm.username"
              :placeholder="$t('AbpAccount[\'UserNameOrEmailAddress\']')"
              name="username"
              type="text"
              tabindex="1"
              autocomplete="on"
            />
          </el-form-item>
          <h5>{{ $t('MyAbpVnext["Login:Password"]') }}</h5>
          <el-tooltip
            v-model="capsTooltip"
            content="Caps lock is On"
            placement="right"
            manual
          >
            <el-form-item prop="password">
              <span class="svg-container">
                <svg-icon icon-class="password" />
              </span>
              <el-input
                :key="passwordType"
                ref="password"
                v-model="loginForm.password"
                :type="passwordType"
                :placeholder="$t('AbpAccount[\'Password\']')"
                name="password"
                tabindex="2"
                autocomplete="on"
                @keyup.native="checkCapslock"
                @blur="capsTooltip = false"
                @keyup.enter.native="handleLogin"
              />
              <span class="show-pwd" @click="showPwd">
                <svg-icon
                  :icon-class="passwordType === 'password' ? 'eye' : 'eye-open'"
                />
              </span>
            </el-form-item>
          </el-tooltip>

          <el-button
            :loading="loading"
            class="btn"
            type="primary"
            style="width: 100%; margin-bottom: 30px"
            @click.native.prevent="handleLogin"
          >
            {{ $t("AbpAccount['Login']") }}
          </el-button>

          <div style="text-align: right">
            <span style="color: #000; font-size: 14px; padding-right: 15px"
              >{{ $t("AbpUiMultiTenancy['Tenant']") }}
              <el-tooltip
                :content="$t('AbpUiMultiTenancy[\'Switch\']')"
                effect="dark"
                placement="bottom"
              >
                <el-link
                  :underline="false"
                  @click="tenantDialogFormVisible = true"
                  ><i>{{
                    currentTenant
                      ? currentTenant
                      : $t("AbpUiMultiTenancy['NotSelected']")
                  }}</i></el-link
                >
              </el-tooltip>
            </span>
          </div>

          <!-- <p style="font-size:14px;text-align:center;color:#fff;">
        {{ $t("AbpAccount['AreYouANewUser']") }}
        <el-link
          :underline="false"
        ><i>{{ $t("AbpAccount['Register']") }}</i></el-link>
      </p> -->
        </el-form>

        <el-dialog
          :title="$t('AbpUiMultiTenancy[\'SwitchTenant\']')"
          :visible.sync="tenantDialogFormVisible"
        >
          <el-form ref="dataForm" :model="tenant">
            <el-form-item
              :label="$t('AbpUiMultiTenancy[\'Name\']')"
              style="background: rgba(255, 255, 255, 0.1)"
            >
              <el-input
                v-model="tenant.name"
                type="text"
                style="width: 160px; background: #e5e5e5"
                autofocus
              />
              <div>{{ $t("AbpUiMultiTenancy['SwitchTenantHint']") }}</div>
            </el-form-item>
          </el-form>
          <div slot="footer">
            <el-button @click="tenantDialogFormVisible = false" type="info">
              <!-- {{ $t("AbpTenantManagement['Cancel']") }} -->
              取消
            </el-button>
            <el-button
              type="primary"
              :disabled="tenantDisabled"
              @click="saveTenant()"
            >
              <!-- {{ $t("AbpTenantManagement['Save']") }} -->
              保存
            </el-button>
          </div>
        </el-dialog>
      </div>
    </div>
  </div>
</template>

<script>
import LangSelect from "@/components/LangSelect";
import SocialSign from "./components/SocialSignin";

export default {
  name: "Login",
  components: { LangSelect, SocialSign },
  data() {
    return {
      loginForm: {
        username: "admin",
        password: "1q2w3E*",
      },
      loginRules: {
        username: [
          {
            required: true,
            message: this.$i18n.t("AbpAccount['ThisFieldIsRequired.']"),
            trigger: ["blur", "change"],
          },
        ],
        password: [
          {
            required: true,
            message: this.$i18n.t("AbpAccount['ThisFieldIsRequired.']"),
            trigger: ["blur", "change"],
          },
        ],
      },
      passwordType: "password",
      capsTooltip: false,
      loading: false,
      showDialog: false,
      redirect: undefined,
      otherQuery: {},
      tenantDialogFormVisible: false,
      tenant: { name: this.$store.getters.abpConfig.currentTenant.name },
    };
  },
  computed: {
    currentTenant() {
      return this.$store.getters.abpConfig.currentTenant.name;
    },
    tenantDisabled() {
      if (
        this.tenant.name &&
        this.tenant.name === this.$store.getters.abpConfig.currentTenant.name
      ) {
        return true;
      }
      return false;
    },
  },
  watch: {
    $route: {
      handler: function (route) {
        const query = route.query;
        if (query) {
          this.redirect = query.redirect;
          this.otherQuery = this.getOtherQuery(query);
        }
      },
      immediate: true,
    },
  },
  created() {
    // window.addEventListener('storage', this.afterQRScan)
  },
  mounted() {
    if (this.loginForm.username === "") {
      this.$refs.username.focus();
    } else if (this.loginForm.password === "") {
      this.$refs.password.focus();
    }
  },
  destroyed() {
    // window.removeEventListener('storage', this.afterQRScan)
  },
  methods: {
    checkCapslock(e) {
      const { key } = e;
      this.capsTooltip = key && key.length === 1 && key >= "A" && key <= "Z";
    },
    showPwd() {
      if (this.passwordType === "password") {
        this.passwordType = "";
      } else {
        this.passwordType = "password";
      }
      this.$nextTick(() => {
        this.$refs.password.focus();
      });
    },
    handleLogin() {
      this.$refs.loginForm.validate((valid) => {
        if (valid) {
          this.loading = true;
          this.$store
            .dispatch("user/login", this.loginForm)
            .then(() => {
              this.$router.push({
                path: this.redirect || "/",
                query: this.otherQuery,
              });
              this.loading = false;
            })
            .catch(() => {
              this.loading = false;
            });
        } else {
          console.log("error submit!!");
          return false;
        }
      });
    },
    getOtherQuery(query) {
      return Object.keys(query).reduce((acc, cur) => {
        if (cur !== "redirect") {
          acc[cur] = query[cur];
        }
        return acc;
      }, {});
    },
    saveTenant() {
      this.$store
        .dispatch("app/setTenant", this.tenant.name)
        .then((response) => {
          if (response && !response.success) {
            this.$notify({
              title: this.$i18n.t("AbpUi['Error']"),
              message: this.$i18n.t(
                "AbpUiMultiTenancy['GivenTenantIsNotAvailable']",
                [this.tenant.name]
              ),
              type: "error",
              duration: 2000,
            });
            return;
          }

          this.tenantDialogFormVisible = false;
        });
    },
  },
};
</script>

<style lang="scss">
$bg: #283443;
$light_gray: #fff;
$cursor: #fff;

// @supports (-webkit-mask: none) and (not (cater-color: $cursor)) {
//   .login-container .el-input input {
//     color: $cursor;
//   }
// }

/* reset element-ui css */
.login-container {
  .el-input {
    display: inline-block;
    height: 47px;
    width: 85%;
    input {
      background: transparent;
      border: 0px;
      -webkit-appearance: none;
      border-radius: 0px;
      padding: 12px 5px 12px 15px;
      color: #000000;
      height: 47px;
      caret-color: $bg;

      &:-webkit-autofill {
        box-shadow: 0 0 0px 1000px $bg inset !important;
        -webkit-text-fill-color: $cursor !important;
      }
    }
  }

  .el-form-item {
    border: 1px solid rgba(255, 255, 255, 0.1);
    background: rgba(0, 0, 0, 0.1);
    border-radius: 5px;
    color: #454545;
  }
}
</style>

<style lang="scss" scoped>
$bg: #2d3a4b;
$dark_gray: #889aa4;
$light_gray: #eee;

.bodymain {
  padding: 0;
  margin: 0;
  box-sizing: border-box;
}

.container {
  width: 100vw;
  height: 100vh;
  display: grid;
  grid-template-columns: repeat(2, 1fr);
  grid-gap: 18rem;
  padding: 0 2rem;
}

.img {
  display: flex;
  justify-content: flex-end;
  align-items: center;
}
.img img {
  width: 560px;
}

.wave {
  position: fixed;
  height: 100%;
  left: 0;
  bottom: 0;
  z-index: -1;
}

.btn {
  display: block;
  width: 100%;
  height: 47px;
  border-radius: 25px;
  margin: 1rem 0;
  font-size: 1.2rem;
  outline: none;
  border: none;
  background-image: linear-gradient(to right, #32be8f, #38d39f, #32be8f);
  cursor: pointer;
  color: #fff;
  // text-transform: uppercase;
  font-family: "Roboto", sans-serif;
  background-size: 200%;
  transition: 0.5s;
}
.btn:hover {
  background-position: right;
}

.container {
  width: 100vw;
  height: 100vh;
  display: grid;
  grid-template-columns: repeat(2, 1fr);
  grid-gap: 18rem;
  padding: 0 2rem;
}
.login-container {
  display: flex;
  .login-form {
    position: relative;
    width: 520px;
    max-width: 100%;
    padding: 250px 35px 0;
    margin: 0 auto;
    overflow: hidden;
  }

  .tips {
    font-size: 14px;
    color: #fff;
    margin-bottom: 10px;
    span {
      &:first-of-type {
        margin-right: 16px;
      }
    }
  }

  .svg-container {
    padding: 6px 5px 6px 15px;
    // color: $dark_gray;
    vertical-align: middle;
    width: 30px;
    display: inline-block;
  }

  .title-container {
    position: relative;
    .title {
      font-size: 26px;
      margin: 0px auto 40px auto;
      text-align: center;
      font-weight: bold;
    }
    .set-language {
      color: rgb(8, 8, 8);
      position: absolute;
      top: 3px;
      font-size: 18px;
      right: 0px;
      cursor: pointer;
    }
  }

  .show-pwd {
    position: absolute;
    right: 10px;
    top: 7px;
    font-size: 16px;
    cursor: pointer;
    user-select: none;
  }
}

/*媒体查询*/
@media screen and (max-width: 1440px) {
  .container {
    grid-gap: 5rem;
  }
}
@media screen and (max-width: 1024px) {
  .login-form {
    width: 360px !important;
  }

  .img img {
    width: 360px;
  }
}
@media screen and (max-width: 848px) {
  .wave {
    display: none;
  }
  .img {
    display: none;
  }
  .container {
    grid-template-columns: 1fr;
  }
  .login-container {
    justify-content: center;
  }
}
</style>
